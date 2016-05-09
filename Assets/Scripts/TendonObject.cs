#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using NeuroApp;
using System;

[System.Serializable]
public class TendonObject : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public Tendon tendon = new Tendon();
    public Orientation orientation;
    public RectTransform limbRect;
    public SwingDirection swingDirection;
    public Tool tool;
    public ToolSwingDirection toolSwingDirection;

    public HeadReaction head;
    public Text header;
    public Image mainPanel;
    public Color reactionColor = new Color32(251, 221, 97, 255);
    public Color noReactionColor = new Color32(36, 36, 36, 255);
    public float activationRadius = 50.0f;

    public string hyperReflexMessage = "Ouch!";
    public string normalReflexMessage = "Ow!";
    public string hypoReflexMessage = "Hmm.";
    public string absentReflexMessage = "...";

    private Color m_OriginalColor;
    private float m_OriginalAngle;
    private float m_InitialInterval = 0.1f;
    private float m_BackInterval = 0.05f;

    void Start()
    {
        m_OriginalColor = mainPanel.color;
        m_OriginalAngle = limbRect.localRotation.z;
        m_Swinging = false;
    }

    void Update()
    {
        bool isNear = false;
        isNear = Vector2.Distance(Input.mousePosition, transform.position) < activationRadius;
        if (isNear)
        {
            switch (orientation)
            {
                case Orientation.Left:
                    tool.AlternateSprite(0);
                    break;
                case Orientation.Right:
                    tool.AlternateSprite(1);
                    break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        head.Reaction(FaceState.Shocked);

        ToolCursor.canAnimate = true;
    }

    static bool m_Swinging = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        // Don't execute if mid-swing
        if (m_Swinging)
            return;

        m_Swinging = true;

        // Visual feedback: Face reaction
        head.Reaction(FaceState.Ouch);

        // Visual feedback: Swing
        switch (tendon.tendonReflex)
        {
            case Tendon.TendonReflex.Hyperactive:
                header.text = hyperReflexMessage;
                mainPanel.color = reactionColor;
                //Hyper 60degrees
                m_InitialInterval = 0.1f;
                m_BackInterval = 0.05f;
                StartCoroutine(ReflexReaction(60.0f));
                break;
            case Tendon.TendonReflex.Normal:
                //Normal 15degrees
                header.text = normalReflexMessage;
                mainPanel.color = reactionColor;
                m_InitialInterval = 0.125f;
                m_BackInterval = 0.05f;
                StartCoroutine(ReflexReaction(15.0f));
                break;
            case Tendon.TendonReflex.Sluggish:  // Deprecated
                //Hypo 10degrees
                header.text = hypoReflexMessage;
                mainPanel.color = reactionColor;
                m_InitialInterval = 0.1f;
                m_BackInterval = 0.05f;
                StartCoroutine(ReflexReaction(10.0f));
                break;
            case Tendon.TendonReflex.Absent:
                //ReflexReaction(0.0f);
                head.Reaction(FaceState.NoReaction);
                header.text = absentReflexMessage;
                mainPanel.color = noReactionColor;
                m_InitialInterval = 0.1f;
                m_BackInterval = 0.05f;
                StartCoroutine(ReflexReaction(0.0f));
                break;
        }
    }

    IEnumerator ReflexReaction(float angle)
    {
        m_Swinging = true;

        string animTrigger = toolSwingDirection == ToolSwingDirection.Up ? "TapUp" : "TapDown";
        tool.AnimateTool(animTrigger);

        //Small delay for tapper animation before reacting
        yield return new WaitForSeconds(Constants.const_tapper_delay);

        yield return StartCoroutine(Swing(angle, m_InitialInterval, m_BackInterval));

        yield return new WaitForSeconds(Constants.const_reaction_delay); // Delay reaction color

        head.Reaction(FaceState.Neutral);
        mainPanel.color = m_OriginalColor;
        header.text = string.Empty;

        ToolCursor.canAnimate = true;
        m_Swinging = false;
    }

    IEnumerator Swing(float amount, float initialInterval, float backInterval)
    {
        float targetAngle = 0;

        switch (swingDirection)
        {
            case SwingDirection.Up:
                targetAngle = m_OriginalAngle + amount;
                break;
            case SwingDirection.Down:
                targetAngle = m_OriginalAngle - amount;
                break;
        }

        // Set up lerping variables
        float interval = 0;

        Quaternion fromRotation = Quaternion.Euler(limbRect.localEulerAngles);
        //Debug.Log(limbSprite.localRotation.z);
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        // Initial swing
        while (Mathf.Abs(limbRect.localEulerAngles.z - targetRotation.eulerAngles.z) > 1)
        {
            limbRect.localRotation = Quaternion.Slerp(fromRotation, targetRotation, interval += initialInterval);
            //Debug.Log(Mathf.Abs(limbSprite.localEulerAngles.z - targetRotation.eulerAngles.z));
            yield return null;
        }
        limbRect.localRotation = targetRotation;
        interval = 0;

        // Back swing
        fromRotation = targetRotation;
        targetRotation = Quaternion.Euler(0, 0, m_OriginalAngle);

        while (Mathf.Abs(limbRect.localEulerAngles.z - targetRotation.eulerAngles.z) > 1)
        {
            limbRect.localRotation = Quaternion.Slerp(fromRotation, targetRotation, interval += backInterval);
            yield return null;
        }
        limbRect.localRotation = targetRotation;

        // Add slight delay if absent reflexes
        if (tendon.tendonReflex == Tendon.TendonReflex.Absent)
            yield return new WaitForSeconds(0.5f);

        // Reset swing check
        //m_Swinging = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        head.Reaction(FaceState.Neutral);
    }
}

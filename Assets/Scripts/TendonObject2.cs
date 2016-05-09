using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using NeuroApp;
#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class TendonObject2 : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{

    public Tendon tendon = new Tendon();
    public SwingDirection swingDirection;
    public HeadReaction head;
    public Text header;
    public Image mainPanel;
    public Color reactionColor = new Color32(251, 221, 97, 255);
    public float activationRadius = 50.0f;

    public string hyperReflexMessage = "Ouch!";
    public string normalReflexMessage = "Ow!";
    public string hypoReflexMessage = "Hmm.";
    public string absentReflexMessage = "...";
    public float tapperDelay = 0.1f;

    private Color m_OriginalColor;
    private Image m_Image;
    private RectTransform m_RectTransform;
    private float m_OriginalAngle;
    private bool m_Swinging;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        m_RectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        m_OriginalColor = mainPanel.color;
        m_OriginalAngle = m_RectTransform.localRotation.z;
        m_Swinging = false;
    }

    private void LateUpdate()
    {
        m_Image.enabled = (Vector2.Distance(Input.mousePosition, transform.position) < activationRadius) ? true : false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        head.Reaction(FaceState.Shocked);

        ToolCursor.canAnimate = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (m_Swinging)
            return;

        head.Reaction(FaceState.Ouch);
        mainPanel.color = reactionColor;
        switch (tendon.tendonReflex)
        {
            case Tendon.TendonReflex.Hyperactive:
                header.text = hyperReflexMessage;
                //Hyper 60degrees
                StartCoroutine(ReflexReaction(60.0f));
                break;
            case Tendon.TendonReflex.Normal:
                //Normal 30degrees
                header.text = normalReflexMessage;
                StartCoroutine(ReflexReaction(30.0f));
                break;
            case Tendon.TendonReflex.Sluggish:
                //Hypo 10degrees
                header.text = hypoReflexMessage;
                StartCoroutine(ReflexReaction(10.0f));
                break;
            case Tendon.TendonReflex.Absent:
                //ReflexReaction(0.0f);
                header.text = absentReflexMessage;
                break;
            default:
                print("Invalid.");
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        head.Reaction(FaceState.Smile);
        mainPanel.color = m_OriginalColor;
        header.text = string.Empty;

        ToolCursor.canAnimate = false;
    }

    private IEnumerator ReflexReaction(float angle)
    {
        m_Swinging = true;

        //Small delay for tapper animation before reacting
        yield return new WaitForSeconds(tapperDelay);

        StartCoroutine(Swing(angle));
    }

    private IEnumerator Swing(float amount)
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
            default:
                Debug.Log("No implemented for selected SwingDirection");
                break;
        }

        // Set up lerping variables
        float interval = 0;
        Quaternion fromRotation = Quaternion.Euler(m_RectTransform.localEulerAngles);
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        // Initial swing
        while (Mathf.Abs(m_RectTransform.localEulerAngles.z - targetRotation.eulerAngles.z) > 1)
        {
            m_RectTransform.localRotation = Quaternion.Slerp(fromRotation, targetRotation, interval += 0.1f);
            Debug.Log(Mathf.Abs(m_RectTransform.localEulerAngles.z - targetRotation.eulerAngles.z));
            yield return null;
        }
        m_RectTransform.localRotation = targetRotation;
        interval = 0;

        // Back swing
        fromRotation = targetRotation;
        targetRotation = Quaternion.Euler(0, 0, m_OriginalAngle);

        while (Mathf.Abs(m_RectTransform.localEulerAngles.z - targetRotation.eulerAngles.z) > 1)
        {
            m_RectTransform.localRotation = Quaternion.Slerp(fromRotation, targetRotation, interval += 0.05f);
            yield return null;
        }
        m_RectTransform.localRotation = targetRotation;

        // Reset swing bool
        m_Swinging = false;
    }
}

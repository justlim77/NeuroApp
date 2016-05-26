using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NeuroApp;

public class ToolControl : MonoBehaviour
{
    public List<Tool> tools = new List<Tool>();
    public GameObject toolCursor;
    public GameObject localiseButton;
    public Text selectedToolText;
    public GameObject alternateSet;

    public RectTransform bedRectTrans;
    public RectTransform speechRectTrans;
    public Vector2 cranialBedPos;
    public Vector2 cranialBedScale;
    public Vector2 cranialSpeechPos;
    public Vector2 cranialSpeechScale;
    public Image[] toggledImages;
    public Text[] toggledLabels;
    public Button cranialBackButton;

    [SerializeField] int m_ToolUseCount = 0;
    public Vector2 bedOriginalOffsetMin;
    public Vector2 bedOriginalOffsetMax;
    Vector2 bedOriginalScale;
    public Vector2 speechOriginalPos;
    Vector2 speechOriginalScale;

    [SerializeField] bool debug = false;
    [SerializeField] bool activeOnStart = true;
    [SerializeField] Color panelColor;

    void OnEnable()
    {
        if (activeOnStart == true)
            if (m_ToolUseCount >= tools.Count)
                localiseButton.SetActive(true);
    }

    void Awake()
    {
        // Add tools to list
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Tool tool = transform.GetChild(i).GetComponent<Tool>();
        //    tools.Add(tool);
        //}

        bedOriginalScale = bedRectTrans.localScale;
        speechOriginalScale = speechRectTrans.localScale;

        //Init();
        ResetTools();

        gameObject.SetActive(activeOnStart);
    }

    public bool Init()
    {
        bool result = true;

        // Clear selected tool text
        while (!string.IsNullOrEmpty(selectedToolText.text))
            selectedToolText.text = string.Empty;
        result = string.IsNullOrEmpty(selectedToolText.text);
        if (result == false)
            print("Failed to clear tool label!");

        // Deselect any active tools
        ResetTools();

        // Deactivate tool cursor image
        while (toolCursor.activeInHierarchy)
            toolCursor.SetActive(false);
        result = !toolCursor.activeInHierarchy;
        if (result == false)
            print("Failed to deactivate tool cursor image!");

        // Deactivate assess button
        while (localiseButton.activeInHierarchy)
            localiseButton.SetActive(false);
        result = !localiseButton.activeInHierarchy;
        if (result == false)
            print("Failed to deactivate localise button!");

        // Reset tools and tool count
        m_ToolUseCount = 0;

        // Add tools to list
        tools.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Tool tool = transform.GetChild(i).GetComponent<Tool>();
            if (tool != null)
                tools.Add(tool);

        }

        foreach (Tool tool in tools)
            result = tool.Init();
        if (result == false)
            print("Failed to initialize tools!");

        if(activeOnStart == false)
            while (gameObject.activeInHierarchy)
                gameObject.SetActive(false);
        else
            ToggleCranial(false);

        return result;
    }

    void Update()
    {
        if (debug)
        {
            //Debug.Log("Bed anchored position: " + bedRectTrans.anchoredPosition);
            Debug.Log("Speech bubble anchored position: " + speechRectTrans.anchoredPosition);
        }
    }

    public void ResetTools()
    {
        foreach (var tool in tools)
            tool.DeselectTool();
    }

    public void ToolCount()
    {
        m_ToolUseCount++;

        if(activeOnStart && gameObject.activeSelf)
            if (m_ToolUseCount >= tools.Count)
                localiseButton.SetActive(true);
    }

    public void SwitchToolset()
    {
        // Test for main tool panel to show localise button
        //if (activeOnStart && gameObject.activeSelf)
        //    if (m_ToolUseCount >= tools.Count)
        //        localiseButton.SetActive(true);

        alternateSet.SetActive(true);
        gameObject.SetActive(false);
       
    }

    public void ToggleCranial(bool value)
    {
        foreach (Image image in toggledImages)
            image.enabled = !value;
        foreach (Text text in toggledLabels)
            text.enabled = !value;
        speechRectTrans.gameObject.SetActive(false);

        // Back button
        cranialBackButton.gameObject.SetActive(value);

        if (value)
        {
            bedRectTrans.anchoredPosition = cranialBedPos;
            bedRectTrans.localScale = cranialBedScale;

            speechRectTrans.anchoredPosition = cranialSpeechPos;
            speechRectTrans.localScale = cranialSpeechScale;


            localiseButton.SetActive(false);

            Core.BroadcastEvent("OnToggleCranial", this, Constants.const_zoom_delta);
        }
        else
        {
            bedRectTrans.offsetMin = bedOriginalOffsetMin;
            bedRectTrans.offsetMax = bedOriginalOffsetMax;
            bedRectTrans.localScale = Vector3.one;

            speechRectTrans.anchoredPosition = speechOriginalPos;
            speechRectTrans.localScale = Vector3.one;

            PanelManager.Instance.PanelColor(PanelType.Main, panelColor);

            if (activeOnStart == true)
                if (m_ToolUseCount >= tools.Count)
                    localiseButton.SetActive(true);

            Core.BroadcastEvent("OnToggleCranial", this, Constants.const_default_delta);
        }
    }
}

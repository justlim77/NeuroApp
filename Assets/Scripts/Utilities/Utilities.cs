#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class Utilities : MonoBehaviour
{
    #region Public Variables
    public KeyCode restartKey;
    public KeyCode quitKey;
    public GameObject fadeObject;
    public GameObject welcomePanel;
    #endregion

    #region Private Member Variables
    private Ray2D m_Ray2D;
    private RaycastHit2D m_Rayhit2D;
    private Fade m_Fade;
    private Scene m_CurrentScene;
    #endregion

    void Awake ()
    {
        if (restartKey == KeyCode.None)
            restartKey = KeyCode.R;
        if (quitKey == KeyCode.None)
            quitKey = KeyCode.Escape;

        m_Fade = fadeObject.GetComponent<Fade>();
        m_CurrentScene = SceneManager.GetActiveScene();
        QualitySettings.SetQualityLevel(0);
        qualityIndex = QualitySettings.GetQualityLevel();
    }

    void Start()
    {
        StartCoroutine(FadeToClear(welcomePanel));
    }

    void Update()
    {
        if (Input.GetKeyUp(restartKey))
            RestartGame();
        if (Input.GetKeyUp(quitKey))
            QuitGame();
    }

    #region Public Methods
    public void RestartGame()
    {
        StartCoroutine(RunRestartGame());
    }

    public void QuitGame()
    {
        StartCoroutine(RunQuitGame());
    }

    public void ActivatePanel(GameObject _panel)
    {
        //Show cursor if hidden in previous panel
        if (!Cursor.visible)
            Cursor.visible = true;

        StartCoroutine(Fade(_panel));     
    }
    #endregion

    IEnumerator Fade(GameObject _panel)
    {
        m_Fade.fadeType = global::Fade.FadeType.In;
        m_Fade.enabled = true;
        fadeObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        //Only activate panel if it is currently not active
        if (!_panel.activeInHierarchy)
            _panel.SetActive(true);

        m_Fade.fadeType = global::Fade.FadeType.Out;
        fadeObject.SetActive(true);
        m_Fade.enabled = true;

        //Set the current panel to draw on top of every other panel
        _panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);        
    }

    IEnumerator FadeToClear(GameObject panel)
    {
        m_Fade.SetColor(Color.black);
        m_Fade.fadeType = global::Fade.FadeType.Out;
        fadeObject.SetActive(true);
        m_Fade.enabled = true;

        yield return new WaitForSeconds(0.3f);

        //Set the current panel to draw on top of every other panel
        panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);
    }

    IEnumerator FadeToBlack(GameObject panel)
    {
        //m_Fade.SetColor(Color.black);
        m_Fade.fadeType = global::Fade.FadeType.In;
        fadeObject.SetActive(true);
        m_Fade.enabled = true;

        yield return new WaitForSeconds(0.3f);

        //Set the current panel to draw on top of every other panel
        panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);
    }

    IEnumerator RunRestartGame()
    {
#if UNITY_5_3
        SceneManager.LoadScene(m_CurrentScene.buildIndex);
#else
        Application.LoadLevel(Application.loadedLevel);
#endif
        yield return 0;
    }

    IEnumerator RunQuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
        yield return 0;
    }

    void CheckRaycast()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_Rayhit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (m_Rayhit2D.collider != null)
            Debug.Log(m_Rayhit2D.collider.name);
    }

    int qualityIndex;
    int maxQualityIndex = 3;
    public void ChangeQuality()
    {
        //qualityIndex += 1;
        qualityIndex = qualityIndex == maxQualityIndex ? 0 : qualityIndex + 1;

        QualitySettings.SetQualityLevel(qualityIndex);

        Debug.Log("Quality level set to " + QualitySettings.GetQualityLevel());
    }
}
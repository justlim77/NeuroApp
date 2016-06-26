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
    public KeyCode toggleLocaliseKey;
    public GameObject fadeObject;
    public GameObject welcomePanel;
    public GameObject localiseBtn;
    #endregion

    #region Private Member Variables
    private Ray2D _ray2D;
    private RaycastHit2D _rayHit2D;
    private Fade _fade;
    private Scene _currentScene;
    #endregion

    void Awake ()
    {
        if (restartKey == KeyCode.None)
            restartKey = KeyCode.R;
        if (quitKey == KeyCode.None)
            quitKey = KeyCode.Escape;

        _fade = fadeObject.GetComponent<Fade>();
        _currentScene = SceneManager.GetActiveScene();
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
        if (Input.GetKey(quitKey))
            QuitGame();
        if (Input.GetKeyDown(toggleLocaliseKey))
            localiseBtn.SetActive(!localiseBtn.activeSelf);
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

    IEnumerator Fade(GameObject panel)
    {
        _fade.fadeType = global::Fade.FadeType.In;
        yield return _fade.FadeRoutine();

        //Only activate panel if it is currently not active
        if (!panel.activeInHierarchy)
            panel.SetActive(true);


        //Set the current panel to draw on top of every other panel
        panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);        

        _fade.fadeType = global::Fade.FadeType.Out;
        yield return _fade.FadeRoutine();

    }

    IEnumerator FadeToClear(GameObject panel)
    {
        _fade.SetColor(Color.black);
        _fade.fadeType = global::Fade.FadeType.Out;
        fadeObject.SetActive(true);
        _fade.enabled = true;

        yield return new WaitForSeconds(0.3f);

        //Set the current panel to draw on top of every other panel
        panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);
    }

    IEnumerator FadeToBlack(GameObject panel)
    {
        //m_Fade.SetColor(Color.black);
        _fade.fadeType = global::Fade.FadeType.In;
        fadeObject.SetActive(true);
        _fade.enabled = true;

        yield return new WaitForSeconds(0.3f);

        //Set the current panel to draw on top of every other panel
        panel.transform.SetSiblingIndex(fadeObject.transform.GetSiblingIndex() - 1);
    }

    IEnumerator RunRestartGame()
    {
#if UNITY_5_3
        SceneManager.LoadScene(_currentScene.buildIndex);
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
        _rayHit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
        if (_rayHit2D.collider != null)
            Debug.Log(_rayHit2D.collider.name);
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
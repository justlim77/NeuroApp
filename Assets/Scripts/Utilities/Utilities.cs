#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
using System.Collections;
using System.Collections.Generic;

namespace NeuroApp
{
    [System.Serializable]
    public class LocalisingAlgorithmSet
    {
        public LocalisingAlgorithm AlgorithmType = LocalisingAlgorithm.UMNThoracicCord;
        public string ResourcePath;
    }

    public class Utilities : MonoBehaviour
    {
        #region Public Variables
        public KeyCode restartKey;
        public KeyCode quitKey;
        public KeyCode toggleLocaliseKey;
        public GameObject fadeObject;
        public GameObject welcomePanel;
        public GameObject localiseBtn;
        public int OverrideQualityLevel = 2;

        public LocalisingAlgorithmSet[] LocalisingAlgorithmSets;
        #endregion

        #region Private Member Variables
        private Ray2D _ray2D;
        private RaycastHit2D _rayHit2D;
        private Fade _fade;
        private Scene _currentScene;

        private static Dictionary<LocalisingAlgorithm, string> _AlgorithmPaths = new Dictionary<LocalisingAlgorithm, string>();
        #endregion

        void Awake ()
        {
            if (restartKey == KeyCode.None)
                restartKey = KeyCode.R;
            if (quitKey == KeyCode.None)
                quitKey = KeyCode.Escape;

            _fade = fadeObject.GetComponent<Fade>();
            _currentScene = SceneManager.GetActiveScene();
            QualitySettings.SetQualityLevel(OverrideQualityLevel);
            qualityIndex = QualitySettings.GetQualityLevel();

            // Populate algorithm path dictionary
            _AlgorithmPaths.Clear();

            foreach (var set in LocalisingAlgorithmSets)
            {
                _AlgorithmPaths.Add(set.AlgorithmType, set.ResourcePath);
            }
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
    #if UNITY_5_3_OR_NEWER
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

        #region Public Static functions
        public static Sprite GetAlgorithmTexture(LocalisingAlgorithm algorithmType)
        {
            Sprite sprite = null;
            string path = "";

            if (_AlgorithmPaths.TryGetValue(algorithmType, out path))
            {
                sprite = Resources.Load<Sprite>(path);

            }
            else
            {
                Debug.Log("Failed to get localising algorithm Sprite resource path");
            }

            return sprite;
        }
        #endregion
    }
}
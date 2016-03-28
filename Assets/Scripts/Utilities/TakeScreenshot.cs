using UnityEngine;
using System.Collections;
using System.IO;

public class TakeScreenshot : MonoBehaviour {
    public KeyCode screencapKey = KeyCode.F3;

    public static string ScreenshotName(int width, int height) {
        return string.Format("{0}/Screenshots/screen_{1}x{2}_{3}.png",
            Application.dataPath,
            width, height,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    void LateUpdate() {
        if (Input.GetKeyDown(screencapKey)) {
            StartCoroutine(ScreenshotEncode());
        }
    }

    IEnumerator ScreenshotEncode() {
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        yield return 0;

        //byte[] bytes = texture.EncodeToPNG();

        //File.WriteAllBytes(ScreenshotName(Screen.width, Screen.height), bytes);
        Application.CaptureScreenshot(ScreenshotName(Screen.width, Screen.height));
        Debug.Log("Screenshot saved to: " + ScreenshotName(Screen.width, Screen.height));

        DestroyObject(texture);
    }
}

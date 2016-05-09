using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject audioManager;
    public AudioClip bgm;

    void Awake()
    {
        if (audioManager)
            AudioManager.Instance.PlayBGM(bgm);
    }
}

using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject am;
    public AudioClip bgm;

    void Awake()
    {
        if (am)
            AudioManager.Instance.PlayBGM(bgm);
    }
}

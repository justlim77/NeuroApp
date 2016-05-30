using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialLabel : MonoBehaviour
{
    public TextTyper textTyper;

	void Start ()
    {
        textTyper.Init();
	}
}

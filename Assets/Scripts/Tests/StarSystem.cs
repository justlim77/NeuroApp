using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarSystem : MonoBehaviour {

    public Image[] starImages;

	void Start () {
        Init();
	}

    void Init() {
        // Disable all stars
        foreach (Image image in starImages)
            image.enabled = false;

        int starsTotal = Patient.g_PatientCase.caseStars;

        // Enable stars based on number of accumulated stars
        switch (starsTotal) {
            case 1:
                starImages[1].enabled = true;
                break;
            case 2:
                starImages[0].enabled = true;
                starImages[2].enabled = true;
                break;
            case 3:
                starImages[0].enabled = true;
                starImages[1].enabled = true;
                starImages[2].enabled = true;
                break;
            default:
                break;
        }
    }
}

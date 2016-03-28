using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlaySFX : MonoBehaviour, IPointerClickHandler {

    public AudioClip[] m_ClickSFX;

    void Start() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < m_ClickSFX.Length; i++)
        {
            AudioManager.Instance.PlaySFX(m_ClickSFX[i], 1, 0.5f);
        }
    }
}

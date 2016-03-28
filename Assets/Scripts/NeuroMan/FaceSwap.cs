using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class FaceSwap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool attachedToHead;
    public Image faceImage;
    public Sprite swapSprite;

    public RectTransform[] eyes;
    public float defaultEyeSize = 14.0f;
    [Range(1.0f, 2.0f)]
    public float enlargeScale;

    Sprite originalFace;
    Image image;

    void Awake() {
        if (attachedToHead)
            faceImage = null;

        image = faceImage == null ? GetComponent<Image>() : faceImage;

        originalFace = image.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SwapEyes(swapSprite, enlargeScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SwapEyes(originalFace, 1.0f);
    }

    void SwapEyes(Sprite sprite, float scale) {
        image.sprite = sprite;

        scale *= defaultEyeSize;

        foreach (RectTransform eye in eyes) {
            eye.sizeDelta = new Vector2(scale, scale);
        }
    }
}

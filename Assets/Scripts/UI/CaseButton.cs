using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    public class CaseButton : MonoBehaviour
    {
        [SerializeField]
        Button button;

        [SerializeField]
        Text levelText;

        [SerializeField]
        Transform starParent;

        [SerializeField]
        Image[] stars;

        public Button Button
        {
            get
            {
                return button;
            }
        }

        public Image[] CreateStars(int amount, Sprite sprite)
        {
            // Clear all stars
            starParent.Clear();

            stars = new Image[amount];

            for (int i = 0; i < amount; i++)
            {
                // Instantiate gameObject
                GameObject star = new GameObject(string.Format("star_{0}", i));
                star.transform.SetParent(starParent);

                // Initialize stars
                Image image = star.AddComponent<Image>();
                image.sprite = sprite;
                image.color = Constants.const_star_inactive_color;
                image.raycastTarget = false;
                image.preserveAspect = true;
                stars[i] = image;
            }

            return stars;
        }

        public void SetLevelText(string level)
        {
            levelText.text = level;
        }

        public void SetLevelText(int level)
        {
            levelText.text = level.ToString();
        }

        public void SetScore(int score)
        {
            SetInactive();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].color = i < score ? Constants.const_star_active_color : Constants.const_star_inactive_color;
            }
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        void SetInactive()
        {
            foreach (var star in stars)
            {
                star.color = Constants.const_star_inactive_color;
            }
        }
    }
}

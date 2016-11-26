using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace NeuroApp
{
    public class StarSystem : MonoBehaviour
    {
        public static StarSystem Instance { get; private set; }

        public int starCount = 3;
        public Sprite starSprite;

        private StarReward starReward;
        public StarReward StarReward
        {
            get
            {
                return starReward;
            }

            set
            {
                starReward = value;
                SetReward();
            }
        }

        Image[] m_stars;

        void OnDestroy()
        {
            Core.UnsubscribeEvent("OnUpdateBonus", OnUpdateBonus);

            Instance = null;
        }

        void Start()
        {
            if (Instance == null)
                Instance = this;

            Init();

            Core.SubscribeEvent("OnUpdateBonus", OnUpdateBonus);
        }

        public bool Init()
        {
            bool result = true;

            this.transform.Clear();
            m_stars = CreateStars(starCount);

            starReward = StarReward.None;   // Reset star reward flags

            return result;
        }

        Image[] CreateStars(int amount)
        {
            Image[] stars = new Image[amount];

            for (int i = 0; i < amount; i++)
            {
                GameObject star = (GameObject)new GameObject("star_" + i);
                star.transform.SetParent(this.transform);
                stars[i] = star.AddComponent<Image>();
                stars[i].sprite = starSprite;
                stars[i].color = Constants.const_star_inactive_color;
                stars[i].preserveAspect = true;
            }

            return stars;
        }

        void DisableStars()
        {
            for (int i = 0; i < m_stars.Length; i++)
            {
                m_stars[i].color = Constants.const_star_inactive_color;
            }
        }

        void RewardStars(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                m_stars[i].color = Constants.const_star_active_color;
            }

            // Update case stars
            Patient.CaseData.stars = amount;
        }

        object OnUpdateBonus(object sender, object args)
        {
            if (args is bool)
            {
                bool bonusCorrect = (bool)args;
                Patient.CaseData.bonusCorrect = bonusCorrect;
            }
            return null;
        }

        void ToggleStar(bool val)
        {
            //if (val)
            //    star.sprite = enabledSprite;
            //else
            //    star.sprite = disabledSprite;
        }

        void SetReward()
        {
            DisableStars();

            Debug.Log("Reward: " + starReward.ToString());

            switch (starReward)
            {
                case StarReward.None:   // No stars
                    DisableStars();
                    break;
                case (StarReward.LocaliseOnFirstTry | StarReward.NoHintsUsed):    // 3-stars
                    RewardStars(3);
                    break;
                case (StarReward.Localised | StarReward.MCQCorrect): // 2-stars
                    RewardStars(2);
                    break;
                case StarReward.Localised:
                    RewardStars(1);
                    break;
                case StarReward.MCQCorrect:
                    RewardStars(1);
                    break;
            }
        }
    }
}

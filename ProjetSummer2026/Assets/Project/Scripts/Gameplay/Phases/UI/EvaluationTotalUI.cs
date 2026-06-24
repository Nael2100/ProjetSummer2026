using System;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationTotalUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ingredientsOnlyScore;
        [SerializeField] private TextMeshProUGUI orderOnlyScore;
        [SerializeField] private TextMeshProUGUI orderAdditionalScore;
        [SerializeField] private TextMeshProUGUI skillsOnlyScore;
        [SerializeField] private TextMeshProUGUI skillsAdditionalScore;
        [SerializeField] private TextMeshProUGUI resultScore;

        public void Reset()
        {
            ingredientsOnlyScore.text = "";
            orderOnlyScore.text = "";
            orderAdditionalScore.text = "";
            skillsOnlyScore.text = "";
            skillsAdditionalScore.text = "";
            resultScore.text = "";
        }

        public void DisplayIngredientsOnlyScore(int score)
        {
            ingredientsOnlyScore.text = score.ToString();
        }

        public void DisplayOrderAdditionalScore(int score)
        {
            orderAdditionalScore.text = score.ToString();
        }
        public void DisplayOrderOnlyScore(int score)
        {
            orderOnlyScore.text = score.ToString();
        }

        public void DisplaySkillsAdditionalScore(int score)
        {
            skillsAdditionalScore.text = score.ToString();
        }

        public void DisplaySkillsOnlyScore(int score)
        {
            skillsOnlyScore.text = score.ToString();
        }

        public void DisplayResultScore(int score)
        {
            resultScore.text = score.ToString();
        }
    }
}
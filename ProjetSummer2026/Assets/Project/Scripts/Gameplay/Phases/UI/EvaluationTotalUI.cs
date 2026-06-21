using System;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationTotalUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ingredientsOnlyScore;
        [SerializeField] private TextMeshProUGUI orderOnlyScore;
        [SerializeField] private TextMeshProUGUI resultScore;

        public void Reset()
        {
            ingredientsOnlyScore.text = "";
            orderOnlyScore.text = "";
            resultScore.text = "";
        }

        public void DisplayIngredientsOnlyScore(int score)
        {
            ingredientsOnlyScore.text = score.ToString();
        }

        public void DisplayOrderOnlyScore(int score)
        {
            orderOnlyScore.text = score.ToString();
        }

        public void DisplayResultScore(int score)
        {
            resultScore.text = score.ToString();
        }
    }
}
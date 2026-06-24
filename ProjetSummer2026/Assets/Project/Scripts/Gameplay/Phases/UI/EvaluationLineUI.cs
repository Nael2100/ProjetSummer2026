using Plate.Gameplay.Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationLineUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI ingredientScore;
        [SerializeField] private TextMeshProUGUI orderScore;
        [SerializeField] private TextMeshProUGUI skillsScore;

        public void ResetVisual()
        {
            image.sprite = null;
            ingredientScore.text = "";
            orderScore.text = "";
            skillsScore.text = "";
        }
        public void DisplayEvaluationLineImage(BaseIngredient ingredient)
        {
            image.sprite = ingredient.ReturnImage();
        }
        public void DisplayEvaluationLineForIngredient(int score)
        {
            ingredientScore.text = score.ToString();
        }

        public void DisplayEvaluationLineForOrder(int score)
        {
            orderScore.text = score.ToString();
        }

        public void DisplayEvaluationLineForSkills(int score)
        {
            skillsScore.text = score.ToString();
        }
    }
}
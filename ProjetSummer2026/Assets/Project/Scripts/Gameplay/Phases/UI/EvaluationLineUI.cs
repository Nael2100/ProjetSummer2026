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

        public void ResetVisual()
        {
            image.sprite = null;
            ingredientScore.text = "";
            orderScore.text = "";
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
    }
}
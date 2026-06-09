using Plate.Gameplay.Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class ChoiceIngredientUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [field : SerializeField] 
        public Button button {get; private set;}
        public void Display(BaseIngredient ingredient)
        {
            image.sprite = ingredient.ReturnImage();
        }
    }
}
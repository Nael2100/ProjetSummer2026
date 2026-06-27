using Plate.Gameplay.Ingredients;
using TMPro;
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
            TextMeshProUGUI textMesh = image.GetComponentInChildren<TextMeshProUGUI>();
            if (textMesh != null)
            {
                textMesh.text = ingredient.GetName();
            }
        }
    }
}
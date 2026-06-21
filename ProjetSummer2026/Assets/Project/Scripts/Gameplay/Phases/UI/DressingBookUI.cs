using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Player;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private DressingBookOrderUI OrderUI;
        [SerializeField] private DressingBookIngredientTastesUI TastesUI;
        [SerializeField] private DressingBookIngredientEffectsUI EffectsUI;

        public void AssociateIngredients(List<BaseIngredient> ingredients)
        {
            foreach (BaseIngredient ingredient in ingredients)
            {
                ingredient.OnClicked += DisplayIngredient;
            }
        }

        public void DeassociateIngredients(List<BaseIngredient> ingredients)
        {
            foreach (BaseIngredient ingredient in ingredients)
            {
                ingredient.OnClicked -= DisplayIngredient;
            }
        }

        private void DisplayIngredient(BaseIngredient ingredient)
        {
            Debug.Log(ingredient.name);
        }
    }
}
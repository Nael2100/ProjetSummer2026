using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private List<PlateSlot> plateSlots;

        public List<PlateSlot> GetSlots()
        {
            return plateSlots;
        }

        public List<BaseIngredient> ReturnBaseIngredientsOnPlate()
        {
            List<BaseIngredient> ingredients = new List<BaseIngredient>();
            foreach (PlateSlot slot in plateSlots)
            {
                BaseIngredient newIngredient = slot.ReturnIngredient();
                if (newIngredient != null)
                {
                    ingredients.Add(newIngredient);
                }
            }
            return ingredients;
        }
    }
}
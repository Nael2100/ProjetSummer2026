using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PlateRef : MonoBehaviour
    {
        [SerializeField] private List<PlateSlot> plateSlots;
        private List<BaseIngredient> ingredientsOnPlate;
        private IngredientsTastes mainTaste;
        public List<PlateSlot> GetSlots()
        {
            return plateSlots;
        }

        public List<BaseIngredient> ReturnBaseIngredientsOnPlate()
        {
            mainTaste = IngredientsTastes.None;
            List<BaseIngredient> ingredients = new List<BaseIngredient>();
            
            foreach (PlateSlot slot in plateSlots)
            {
                BaseIngredient newIngredient = slot.ReturnIngredient();
                if (newIngredient != null)
                {
                    ingredients.Add(newIngredient);
                }
            }
            ingredientsOnPlate = ingredients;
            return ingredients;
        }

        public int PointsForTypeOnPlate(IngredientsTypes type, int pointsForIngredients)
        {
            int total = 0;
            foreach (BaseIngredient ing in ingredientsOnPlate)
            {
                if (((IList)ing.GetTypes()).Contains(type))
                {
                    total += pointsForIngredients;
                }
            }
            return total;
        }

        public int PointsForIdenticalOnPlate(string nameCheck, int pointsForIngredients)
        {
            int total = 0;
            foreach (BaseIngredient ing in ingredientsOnPlate)
            {
                if (ing.GetName() == nameCheck)
                {
                    total += pointsForIngredients;
                }
            }
            return total;
        }

        public int PointsForMainTaste(IngredientsTastes tasteCheck, int pointsForTaste)
        {
            if (mainTaste == IngredientsTastes.None)
            {
                Dictionary<IngredientsTastes, int> totalTastes = new Dictionary<IngredientsTastes, int>();
                foreach (BaseIngredient ing in ingredientsOnPlate)
                {
                    foreach (TasteValue tasteValue in ing.GetTastes())
                    {
                        if (totalTastes.ContainsKey(tasteValue.taste))
                        {
                            totalTastes[tasteValue.taste] += tasteValue.amount;
                        }
                        else
                        {
                            totalTastes.Add(tasteValue.taste, tasteValue.amount);
                        }
                    }
                }
                IngredientsTastes maxTaste = IngredientsTastes.None;
                int maxTasteValue = 0;
                foreach (IngredientsTastes taste in totalTastes.Keys)
                {
                    if (totalTastes[taste] > maxTasteValue)
                    {
                        maxTaste = taste;
                        maxTasteValue = totalTastes[taste];
                    }
                }
                mainTaste = maxTaste;
            }
            if (mainTaste == tasteCheck)
            {
                return pointsForTaste;
            }
            return 0;
        }
    }
}
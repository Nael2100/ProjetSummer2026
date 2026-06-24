using Plate.Core.Scriptable.Ingredients;
using Plate.Core.Scriptable.Ingredients.IngredientsDataVariants;
using Plate.Gameplay.Phases;
using UnityEngine;

namespace Plate.Gameplay.Ingredients.IngredientVariants
{
    public class Ingredient1 : BaseIngredient
    {
        
        public override int CalculatePoints(PlateRef plate)
        {
            int total = 0;
            if (dataRef is Ingredient1Data variantData)
            {
                total += plate.PointsForIdenticalOnPlate(GetName(), variantData.PointsForTomato);
                total += plate.PointsForTypeOnPlate(IngredientsTypes.Cheese, variantData.PointsForCheese);
                total += plate.PointsForMainTaste(IngredientsTastes.Acid, variantData.PointsForMainAcidity);
            }
            return total;
        }
        
        
    }
}
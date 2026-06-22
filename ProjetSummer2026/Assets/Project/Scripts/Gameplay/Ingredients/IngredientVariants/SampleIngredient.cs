using Plate.Gameplay.Phases;
using UnityEngine;

namespace Plate.Gameplay.Ingredients.IngredientVariants
{
    public class SampleIngredient : BaseIngredient
    {
        public override int CalculatePoints(PlateRef plate)
        {
            return 1;
        }
    }
}
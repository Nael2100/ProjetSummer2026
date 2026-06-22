using UnityEngine;

namespace Plate.Core.Scriptable.Ingredients.IngredientsDataVariants
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Ingredients/Tomato", order = 0)]
    public class IngredientTomatoData : BaseIngredientData
    {
        public int PointsForTomato;
        public int PointsForCheese;
        public int PointsForMainAcidity;
    }
}
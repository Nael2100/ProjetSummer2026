using UnityEngine;

namespace Plate.Core.Scriptable.Ingredients.IngredientsDataVariants
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Ingredients/001", order = 0)]
    public class Ingredient1Data : BaseIngredientData
    {
        public int PointsForTomato;
        public int PointsForCheese;
        public int PointsForMainAcidity;
    }
}
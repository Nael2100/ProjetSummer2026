using System.Collections.Generic;
using Plate.Gameplay.Ingredients;

namespace Plate.Gameplay.Orders.OrderVariant
{
    public class SampleOrder : BaseOrder
    {
        public override List<int> CalculatePoints(List<BaseIngredient> ingredients)
        {
            List<int> points = new List<int>();
            foreach (BaseIngredient ingredient in ingredients)
            {
                points.Add(1);
            }
            return points;
        }
    }
}
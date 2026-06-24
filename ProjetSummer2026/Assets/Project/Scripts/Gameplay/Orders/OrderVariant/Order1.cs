using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Core.Scriptable.Order.OrderDatasVariants;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Orders.OrderVariant
{
    public class Order1 : BaseOrder
    {
        public override List<int> CalculatePoints(List<BaseIngredient> ingredients)
        {
            List<int> points = new List<int>();
            if (dataRef is Order1Data variantData)
            {
                foreach (BaseIngredient ingredient in ingredients)
                {
                    points.Add(CheckIfIngredientIsType(ingredient, IngredientsTypes.Fruit, variantData.pointsForFruits));
                }
            }
            return points;
        }

        public override int CalculateOverallAdditionalPoints(List<BaseIngredient> ingredients)
        {
            return 0;
        }
    }
}
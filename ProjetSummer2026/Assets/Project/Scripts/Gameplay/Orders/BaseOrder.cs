using System.Collections.Generic;
using System.Linq;
using Plate.Core.Scriptable.Ingredients;
using Plate.Core.Scriptable.Order;
using Plate.Gameplay.Ingredients;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plate.Gameplay.Orders
{
    public abstract class BaseOrder : MonoBehaviour
    {
        [SerializeField] protected BaseOrderData dataRef;

        public string ReturnOrderTitle()
        {
            return dataRef.Title;
        }

        public string ReturnOrderDescription()
        {
            return dataRef.Description;
        }

        public List<string> ReturnOrderEffectsTexts()
        {
            return dataRef.Effects;
        }

        public abstract List<int> CalculatePoints(List<BaseIngredient> ingredients);
        public abstract int CalculateOverallAdditionalPoints(List<BaseIngredient> ingredients);

        public int CheckIfIngredientIsType(BaseIngredient ing, IngredientsTypes typeCheck, int pointsForType)
        {
            if (ing.GetTypes().Contains(typeCheck))
            {
                return pointsForType;
            }
            return 0;
        }
    }
}
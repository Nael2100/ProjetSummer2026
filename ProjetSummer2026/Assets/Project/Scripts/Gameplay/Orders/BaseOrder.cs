using System.Collections.Generic;
using Plate.Core.Scriptable.Order;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Orders
{
    public abstract class BaseOrder : MonoBehaviour
    {
        [SerializeField] private BaseOrderData data;

        public string ReturnOrderTitle()
        {
            return data.Title;
        }

        public string ReturnOrderDescription()
        {
            return data.Description;
        }

        public List<string> ReturnOrderEffectsTexts()
        {
            return data.Effects;
        }

        public abstract List<int> CalculatePoints(List<BaseIngredient> ingredients);
    }
}
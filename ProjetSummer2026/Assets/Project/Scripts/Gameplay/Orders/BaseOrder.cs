using System.Collections.Generic;
using Plate.Core.Scriptable.Order;
using UnityEngine;

namespace Plate.Gameplay.Orders
{
    public class BaseOrder : MonoBehaviour
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
    }
}
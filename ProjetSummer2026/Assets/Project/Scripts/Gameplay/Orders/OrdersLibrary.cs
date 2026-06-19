using System.Collections.Generic;
using Plate.Core.Scriptable.Order;
using UnityEngine;

namespace Plate.Gameplay.Orders
{
    public class OrdersLibrary : MonoBehaviour
    {
        [SerializeField] private List<BaseOrder> orders;

        public BaseOrder ReturnRandomOrder()
        {
            GameObject newIngredient = Instantiate(orders[Random.Range(0, orders.Count)].gameObject, transform);
            newIngredient.name = newIngredient.GetComponent<BaseOrder>().ReturnOrderTitle();
            return newIngredient.GetComponent<BaseOrder>();
        }
    }
}
using UnityEngine;

namespace Plate.Core.Scriptable.Order.OrderDatasVariants
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Order/001", order = 0)]
    public class Order1Data : BaseOrderData
    {
        public int pointsForFruits;
    }
}
using System;
using Plate.Gameplay.Orders;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class OrderPhase : Phase
    {
        [SerializeField] private OrdersLibrary ordersLibrary;
        private BaseOrder order;
        
        public event Action<BaseOrder> OrderChanged;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("OrderPhaseStart");
            SelectOrder();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("OrderPhaseEnd");
        }

        private void SelectOrder()
        {
            order = ordersLibrary.ReturnRandomOrder();
            PhasePlayerRef.SetOrder(order);
            OrderChanged?.Invoke(order);
        }
    }
}
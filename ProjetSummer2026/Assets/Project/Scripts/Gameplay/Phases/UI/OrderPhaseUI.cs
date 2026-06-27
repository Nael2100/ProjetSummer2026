using System;
using System.Collections.Generic;
using NUnit.Framework;
using Plate.Gameplay.Orders;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class OrderPhaseUI : PhaseUI
    {
        [SerializeField] private OrderPhase phase;
        [SerializeField] private OrderReminderUI orderReminderUI;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            changePhaseButton.gameObject.SetActive(false);
            phase.OrderChanged += DisplayOrder;
            SetButton();
        }

        private void DisplayOrder(BaseOrder order)
        {
            orderReminderUI.DisplayOrderReminder(order, true, true);
            SetButton();
        }
    }
}
using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Orders;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingPhaseUI : PhaseUI
    {
        [SerializeField] private DressingPhase phase;
        [SerializeField] private DressingInventoryUI inventory;
        [SerializeField] private DressingBookUI dressingBook;
        [SerializeField] private OrderReminderUI orderReminder;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            phase.OnPhaseBeginEvent += SetUp;
            phase.OnDisplayInventory += DisplayUI;
            phase.OnUndisplayInventory += UnSetUpBook;
            orderReminder.OnOrderClicked += DisplayOrderOnBook;
        }

        private void SetUp(Phase phase)
        {
            changePhaseButton.gameObject.SetActive(false);
            orderReminder.DisplayOrderReminder(phase.GetCurrentOrder(), false);
            dressingBook.DisplayOrder(phase.GetCurrentOrder());
        }
        private void DisplayUI(List<BaseIngredient> ingredients)
        {
            DisplayInventory(ingredients); 
            SetUpBook(ingredients);
            SetButton();
        }

        private void DisplayInventory(List<BaseIngredient> ingredients)
        {
            inventory.DisplayInventory(ingredients);
        }

        private void SetUpBook(List<BaseIngredient> ingredients)
        {
            dressingBook.AssociateIngredients(ingredients);
        }

        private void UnSetUpBook(List<BaseIngredient> ingredients)
        {
            dressingBook.DeassociateIngredients(ingredients);
        }

        private void DisplayOrderOnBook(BaseOrder order)
        {
            dressingBook.DisplayOrder(order);
        }
        
    }
}
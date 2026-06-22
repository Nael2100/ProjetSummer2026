using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingPhaseUI : PhaseUI
    {
        [SerializeField] private DressingPhase phase;
        [SerializeField] private DressingInventoryUI inventory;
        [SerializeField] private DressingBookUI dressingBook;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            phase.OnDisplayInventory += DisplayUI;
            phase.OnUndisplayInventory += UnSetUpBook;
            
        }

        private void DisplayUI(List<BaseIngredient> ingredients)
        {
            changePhaseButton.gameObject.SetActive(false);
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
        
    }
}
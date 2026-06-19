using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingPhaseUI : MonoBehaviour
    {
        [SerializeField] private DressingPhase phase;
        [SerializeField] private DressingInventoryUI inventory;
        [SerializeField] private DressingBookUI dressingBook;

        private void Awake()
        {
            phase.OnPhaseBeginEvent += DisplayUI;
            phase.OnPhaseEndEvent += UnSetUpBook;
        }

        private void DisplayUI(Phase codePhase)
        {
            if (codePhase == phase)
            {
                DisplayInventory(PlayerRef.instance.GetInventory());
                SetUpBook();
            }
            
        }

        private void DisplayInventory(List<BaseIngredient> ingredients)
        {
            inventory.DisplayInventory(ingredients);
        }

        private void SetUpBook()
        {
            dressingBook.AssociateIngredients();
        }

        private void UnSetUpBook(Phase codePhase)
        {
            if (codePhase == phase)
            {
                dressingBook.DeassociateIngredients();
            }
        }
        
    }
}
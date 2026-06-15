using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingPhaseUI : MonoBehaviour
    {
        [SerializeField] private DressingPhase phase;
        [SerializeField] private DressingInventoryUI inventory;

        private void Awake()
        {
            phase.DisplayUI += DisplayUI;
        }

        private void DisplayUI(List<BaseIngredient> ingredients)
        {
            DisplayInventory(ingredients);
        }

        private void DisplayInventory(List<BaseIngredient> ingredients)
        {
            inventory.DisplayInventory(ingredients);
        }
        
    }
}
using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Player;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Player
{
    public class PlayerRef : MonoBehaviour
    {
        public static PlayerRef instance;
        
        [SerializeField] private PlayerData data;
        private List<BaseIngredient> Inventory = new List<BaseIngredient>();
        private int InventorySize;
        private float ChoiceTimerDuration;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            InventorySize = data.inventorySize;
            ChoiceTimerDuration = data.choiceTime;
        }

        public bool AddToInventory(BaseIngredient ingredient)
        {
            if (Inventory.Count < InventorySize)
            {
                Inventory.Add(ingredient);
                return true;
            }
            return false;
        }

        public float ReturnChoiceTimerDuration()
        {
            return ChoiceTimerDuration;
        }
    }
}
using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Player;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        public static Player instance { get; private set; }
        
        [SerializeField] private PlayerData data;
        private List<BaseIngredient> Inventory = new List<BaseIngredient>();
        private int InventorySize;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            InventorySize = data.inventorySize;
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
    }
}
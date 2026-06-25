using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Grade;
using Plate.Core.Scriptable.Player;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Orders;
using UnityEngine;

namespace Plate.Gameplay.Player
{
    public class PlayerRef : MonoBehaviour
    {
        [SerializeField] private PlayerData data;
        private List<BaseIngredient> Inventory = new List<BaseIngredient>();
        private int InventorySize;
        private float ChoiceTimerDuration;
        private BaseOrder currentOrder;
        private GradeData currentGrade;
        
        private int starsAmount;
        
        private void Awake()
        {
            InventorySize = data.inventorySize;
            ChoiceTimerDuration = data.choiceTime;
        }

        public void EmptyInventory()
        {
            Inventory.Clear();
        }

        public bool AddToInventory(BaseIngredient ingredient)
        {
            if (Inventory.Count < InventorySize)
            {
                Inventory.Add(ingredient);
                if (Inventory.Count == InventorySize)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public float GetChoiceTimerDuration()
        {
            return ChoiceTimerDuration;
        }

        public List<BaseIngredient> GetInventory()
        {
            return Inventory;
        }

        public void SetOrder(BaseOrder order)
        {
            currentOrder = order;
        }

        public BaseOrder GetOrder()
        {
            return currentOrder;
        }

        public void SetGrade(GradeData grade)
        {
            Debug.Log(grade);
            currentGrade = grade;
            
        }

        public GradeData GetGrade()
        {
            return currentGrade;
        }

        public void AddStars(int stars)
        {
            starsAmount += stars;
        }

        public int GetStars()
        {
            return starsAmount;
        }

        public int GetMalusForWaste()
        {
            return data.malusForWaste;
        }
    }
}
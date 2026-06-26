using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Grade;
using Plate.Core.Scriptable.Player;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Orders;
using Plate.Gameplay.Save;
using Plate.Gameplay.Skills;
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
        private int daysLeft;
        private string[] skills = new string[0];
        private string playerName = "Tartempion";
        
        private int starsAmount;
        
        private void Awake()
        {
            starsAmount = SaveManager.Instance.playerStars;
            ChoiceTimerDuration = data.choiceTime;
            playerName = SaveManager.Instance.playerName;
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
            currentGrade = grade;
            InventorySize = currentGrade.inventorySIze;
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

        public void SetDaysLeft(int newDaysLeft)
        {
            daysLeft = newDaysLeft;
        }

        public int GetDaysLeft()
        {
            return daysLeft;
        }

        public void UpgradeInventoryCapacity(int size)
        {
            InventorySize = size;
        }

        public void SetSkills(string[] newSkills)
        {
            skills = newSkills;
        }

        public string[] GetSkills()
        {
            return skills;
        }

        public string GetPlayerName()
        {
            return playerName;
        }
    }
}
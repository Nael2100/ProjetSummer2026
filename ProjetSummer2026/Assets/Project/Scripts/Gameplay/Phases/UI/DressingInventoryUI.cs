using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingInventoryUI : MonoBehaviour
    {
        [SerializeField] private List<InventoryPlateSlot> inventoryIngredientsSpots;
        
        private List<BaseIngredient> inventoryIngredients;
        private int maxPage;
        private int currentPage;
        private int nbIngredients;
        private int maxIndex;

        private void Awake()
        {
            maxIndex = inventoryIngredientsSpots.Count;
        }

        private void FindMaxPage(int quantity)
        {
            maxPage = 0;
            int i = 0;
            while (i < quantity)
            {
                maxPage++;
                i += maxIndex;
            }
        }
        public void DisplayInventory(List<BaseIngredient> ingredients)
        {
            currentPage = 0;
            inventoryIngredients = ingredients;
            nbIngredients = ingredients.Count;
            FindMaxPage(nbIngredients);
            int slotIndex = 0;
            int tempPageNumber = 0;
            for (int i = 0; i < nbIngredients; i++)
            {
                foreach (InventoryPlateSlot slot in inventoryIngredientsSpots)
                {
                    slot.SetIngredientsQuantity(maxPage);
                    inventoryIngredients[i].AddAvailableSlot(slot);
                }
                if (slotIndex >= maxIndex)
                {
                    slotIndex = 0;
                    tempPageNumber ++;
                }
                DisplayAllIngredient(slotIndex, inventoryIngredients[i], tempPageNumber);
                slotIndex++;
            }
            DisplayPage();
        }

        public void TurnPage(bool forward)
        {
            if (forward)
            {
                currentPage++;
                if (currentPage >= maxPage)
                {
                    currentPage = 0;
                }
            }
            else
            {                
                currentPage--;
                if (currentPage < 0)
                {
                    currentPage = 0;
                }

            }
            DisplayPage();
        }
        public void DisplayPage()
        {
            for (int i = 0; i < maxIndex; i++)
            {
                inventoryIngredientsSpots[i].HideIngredients();
                int newIndex = i * currentPage;
                if (newIndex < nbIngredients)
                {
                    DisplayIngredient(i, currentPage);
                }
            }
        }

        private void DisplayAllIngredient(int index, BaseIngredient ingredient, int tempPageNumber)
        {
            if (index < maxIndex)
            {
                Debug.Log(tempPageNumber);
                Debug.Log(index);
                InventoryPlateSlot slot = inventoryIngredientsSpots[index];
                slot.Associate(ingredient, tempPageNumber);
                slot.Associate(ingredient);
                ingredient.gameObject.GetComponent<Image>().sprite = ingredient.ReturnImage();
                slot.HideIngredients();
            }
            
        }

        private void DisplayIngredient(int index, int page)
        {
            inventoryIngredientsSpots[index].ShowIngredient(page);
        }
    }
}
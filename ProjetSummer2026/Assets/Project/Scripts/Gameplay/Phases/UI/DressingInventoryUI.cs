using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingInventoryUI : MonoBehaviour
    {
        [SerializeField] private List<GameObject> inventoryIngredientsSpots;

        private int nbIngredients;

        int currentIndex = 0;
        int maxIndex = 0;

        private void Awake()
        {
            nbIngredients = inventoryIngredientsSpots.Count;
        }

        public void DisplayInventory(List<BaseIngredient> ingredients)
        {
            currentIndex = 0;
            maxIndex = ingredients.Count;
            for (int i = 0; i < nbIngredients; i++)
            {
                if (i < maxIndex)
                {
                    DisplayIngredient(i, ingredients[i]);
                }
                
            }
        }

        private void DisplayIngredient(int index, BaseIngredient ingredient)
        {
            if (index < maxIndex)
            {
                ingredient.transform.SetParent(inventoryIngredientsSpots[index].transform);
                ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                ingredient.SetBasePosition(ingredient.transform.position);
                ingredient.SetInventorySlot(inventoryIngredientsSpots[index].GetComponent<PlateSlot>());
            }
        }
    }
}
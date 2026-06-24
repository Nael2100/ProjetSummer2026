using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class InventoryPlateSlot : PlateSlot
    {
        
        private BaseIngredient[] ingredients;
        private int pageNote;
        public void Associate(BaseIngredient ingredient, int newPage = -10)
        {
            if (newPage >= 0)
            {
                pageNote = newPage;
            }
            occupied = true;
            ingredients[pageNote]= ingredient;
            ingredient.transform.SetParent(transform);
            ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            ingredient.SetBasePosition(ingredient.transform.position);
            ingredient.SetInventorySlot(this);
        }

        public void SetOccupied()
        {
            occupied = true;
        }

        public void SetIngredientsQuantity(int quantity)
        {
            if (ingredients == null)
            {
                ingredients = new BaseIngredient[quantity];
            }
        }

        public void IngredientConnected(BaseIngredient ingredient)
        {
            ingredients[pageNote] = ingredient;
        }

        public void IngredientDisconnected(BaseIngredient ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == ingredient)
                {
                    ingredients[i] = null;
                }
            }
        }

        public void ShowIngredient(int page)
        {
            pageNote = page;
            HideIngredients();
            if (page < ingredients.Length)
            {
                if (ingredients[page] != null)
                {
                    ingredients[page].gameObject.SetActive(true);
                    occupied = true;
                }
            }
        }

        public void HideIngredients()
        {
            occupied = false;
            foreach (BaseIngredient found in ingredients)
            {
                if (found != null)
                {
                    if (found.GetSlot() == this)
                    {
                        
                        found.gameObject.SetActive(false);
                    }
                }
                
            }
        }
    }
}
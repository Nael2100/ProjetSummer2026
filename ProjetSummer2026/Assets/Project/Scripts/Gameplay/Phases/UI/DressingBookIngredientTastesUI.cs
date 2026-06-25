using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookIngredientTastesUI : MonoBehaviour
    {
        [SerializeField] private List<TypeIconUI> types;
        [SerializeField] private List<TextMeshProUGUI> tastes;
        [SerializeField] private List<TextMeshProUGUI> tastesScore;
        public void Display(BaseIngredient ingredient)
        {
            for (int i = 0; i < types.Count; i++)
            {
                types[i].Hide();
                if (i < ingredient.GetTypes().Length)
                {
                    types[i].Display(ingredient.GetTypes()[i].ToString());
                }
            }
            for (int i = 0; i < tastes.Count; i++)
            {
                tastes[i].text = "";
                tastesScore[i].text = "";
                if (i < ingredient.GetTastes().Length)
                {
                    tastes[i].text = ingredient.GetTastes()[i].taste.ToString();
                    tastesScore[i].text = ingredient.GetTastes()[i].amount.ToString();
                }
            }
        }
    }
}
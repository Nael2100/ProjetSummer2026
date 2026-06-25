using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Player;
using TMPro;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private DressingBookIngredientsPageMarksUI switchbuttons;
        [SerializeField] private DressingBookOrderUI OrderUI;
        [SerializeField] private DressingBookIngredientTastesUI TastesUI;
        [SerializeField] private DressingBookIngredientEffectsUI EffectsUI;

        private BaseIngredient currentIngredient;

        private void Awake()
        {
            switchbuttons.SwitchToEffects += SwitchToEffects;
            switchbuttons.SwitchToTastes += SwitchToTastes;
            switchbuttons.gameObject.SetActive(false);
        }

        public void AssociateIngredients(List<BaseIngredient> ingredients)
        {
            foreach (BaseIngredient ingredient in ingredients)
            {
                ingredient.OnClicked += DisplayIngredient;
            }
        }

        public void DeassociateIngredients(List<BaseIngredient> ingredients)
        {
            foreach (BaseIngredient ingredient in ingredients)
            {
                ingredient.OnClicked -= DisplayIngredient;
            }
        }

        private void DisplayIngredient(BaseIngredient ingredient)
        {
            currentIngredient = ingredient;
            title.text = currentIngredient.GetName();
            description.text = currentIngredient.ReturnDescription();
            switchbuttons.gameObject.SetActive(true);
            SwitchToEffects();
        }

        private void SwitchToEffects()
        {
            TastesUI.gameObject.SetActive(false);
            EffectsUI.gameObject.SetActive(true);
            EffectsUI.Display(currentIngredient);
        }

        private void SwitchToTastes()
        {
            TastesUI.gameObject.SetActive(true);
            EffectsUI.gameObject.SetActive(false);
            TastesUI.Display(currentIngredient);
        }
    }
}
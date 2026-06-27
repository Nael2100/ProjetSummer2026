using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Orders;
using Plate.Gameplay.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class DressingBookUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Image image;
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
            image.sprite = currentIngredient.ReturnImage();
            switchbuttons.gameObject.SetActive(true);
            SwitchToEffects();
        }

        public void DisplayOrder(BaseOrder order)
        {
            title.text = order.ReturnOrderTitle();
            description.text = order.ReturnOrderDescription();
            image.sprite = order.ReturnOrderClientData().clientIcon;
            HideAll();
            OrderUI.Display(order);
        }

        private void SwitchToEffects()
        {
            HideAll();
            switchbuttons.gameObject.SetActive(true);
            EffectsUI.Display(currentIngredient);
        }

        private void SwitchToTastes()
        {
            HideAll();
            switchbuttons.gameObject.SetActive(true);
            TastesUI.Display(currentIngredient);
        }

        private void HideAll()
        {
            switchbuttons.gameObject.SetActive(false);
            TastesUI.gameObject.SetActive(false);
            EffectsUI.gameObject.SetActive(false);
            OrderUI.gameObject.SetActive(false);
        }
    }
}
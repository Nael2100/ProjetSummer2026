using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class ChoicePhaseUI : PhaseUI
    {
        [SerializeField] private ChoicePhase phase;
        [SerializeField] private List<ChoiceIngredientUI> ingredientsChoiceUI;
        [SerializeField] private ChoiceTimerUI timerUI;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            phase.DisplayChoicesEvent += DisplayIngredientsUI;
            phase.TimerStartedEvent += StartTimerUI;
            phase.AllIngredientsSelectedEvent += UnDisplayIngredientsUI;
            phase.AllIngredientsSelectedEvent += SetButton;
        }

        private void DisplayIngredientsUI(int index, BaseIngredient ingredient)
        {
            changePhaseButton.gameObject.SetActive(false);
            if (ingredientsChoiceUI[index] != null)
            {
                ChoiceIngredientUI currentUI = ingredientsChoiceUI[index];
                currentUI.gameObject.SetActive(true);
                currentUI.Display(ingredient);
                currentUI.button.onClick.RemoveAllListeners();
                currentUI.button.onClick.AddListener(() => phase.AddIngredientToInventory(index));
            }
        }

        private void UnDisplayIngredientsUI()
        {
            foreach (ChoiceIngredientUI ui in ingredientsChoiceUI)
            {
                ui.gameObject.SetActive(false);
            }
        }

        private void StartTimerUI()
        {
            timerUI.StartTimer();
        }
    }
}
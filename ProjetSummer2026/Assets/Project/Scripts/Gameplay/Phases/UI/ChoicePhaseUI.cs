using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class ChoicePhaseUI : MonoBehaviour
    {
        [SerializeField] private ChoicePhase phase;
        [SerializeField] private List<ChoiceIngredientUI> ingredientsChoiceUI;
        [SerializeField] private ChoiceTimerUI timerUI;
        private void Awake()
        {
            phase.DisplayChoicesEvent += DisplayIngredientsUI;
            phase.TimerStartedEvent += StartTimerUI;
        }

        private void DisplayIngredientsUI(int index, BaseIngredient ingredient)
        {
            if (ingredientsChoiceUI[index] != null)
            {
                ChoiceIngredientUI currentUI = ingredientsChoiceUI[index];
                currentUI.Display(ingredient);
                currentUI.button.onClick.RemoveAllListeners();
                currentUI.button.onClick.AddListener(() => phase.AddIngredientToInventory(index));
            }
        }

        private void StartTimerUI()
        {
            timerUI.StartTimer();
        }
    }
}
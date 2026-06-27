using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class ChoicePhaseUI : PhaseUI
    {
        [SerializeField] private ChoicePhase phase;
        [SerializeField] private List<ChoiceIngredientUI> ingredientsChoiceUI;
        [SerializeField] private Transform chosenIngredientsParent;
        [SerializeField] private ChoiceTimerUI timerUI;
        [SerializeField] private OrderReminderUI orderReminderUI;
        [SerializeField] private GameObject GetReadyInfoUI;
        [SerializeField] private Button StartButton;
        
        private List<ChoiceIngredientUI> chosenIngredientsUI;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            phase.OnPhaseBeginEvent += SetUp;
            phase.DisplayChoicesEvent += DisplayIngredientsUI;
            phase.TimerStartedEvent += StartTimerUI;
            phase.AllIngredientsSelectedEvent += UnDisplayIngredientsUI;
            phase.AllIngredientsSelectedEvent += SetButton;
            phase.OnIngredientSelected += DisplayChosenIngredientsUI;
            chosenIngredientsUI = new List<ChoiceIngredientUI>();
            for (int i = 0; i < chosenIngredientsParent.childCount; i++)
            {
                Transform child = chosenIngredientsParent.GetChild(i);
                if (child.gameObject.GetComponent<ChoiceIngredientUI>() != null)
                {
                    chosenIngredientsUI.Add(child.gameObject.GetComponent<ChoiceIngredientUI>());
                }
            }
        }

        private void SetUp(Phase newPhase)
        {
            GetReadyInfoUI.SetActive(true);
            orderReminderUI.DisplayOrderReminder(phase.GetCurrentOrder(), true, true);
            foreach (ChoiceIngredientUI ui in chosenIngredientsUI)
            {
                ui.gameObject.SetActive(false);
            }
            UnDisplayIngredientsUI();
            StartButton.onClick.AddListener(phase.SelectIngredients);
        }
        private void DisplayIngredientsUI(int index, BaseIngredient ingredient)
        {
            changePhaseButton.gameObject.SetActive(false);
            GetReadyInfoUI.SetActive(false);
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

        private void DisplayChosenIngredientsUI(BaseIngredient ingredient)
        {
            foreach (ChoiceIngredientUI ui in chosenIngredientsUI)
            {
                if (!ui.gameObject.activeInHierarchy)
                {
                    ui.gameObject.SetActive(true);
                    ui.Display(ingredient);
                    break;
                }
            }
        }
    }
}
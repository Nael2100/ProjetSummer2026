using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Events;
using Action = System.Action;

namespace Plate.Gameplay.Phases
{
    public class ChoicePhase : Phase
    {
        [SerializeField] private int choices;
        [SerializeField] private IngredientsLibrary ingredientsLibrary;
        [SerializeField] private ChoicePhaseTimer timer;
        
        private List<BaseIngredient> currentIngredients;
        
        public event System.Action<int,BaseIngredient> DisplayChoicesEvent;
        public event Action TimerStartedEvent;

        private void Awake()
        {
            timer.OnTimerEnd += AutoSelect;
        }

        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("ChoicePhaseStart");
            ResetIngredients();
            SelectIngredients();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("ChoicePhaseEnd");
        }

        private void ResetIngredients()
        {
            ingredientsLibrary.ClearIngredients();
            PlayerRef.EmptyInventory();
        }

        private void SelectIngredients()
        {
            if (!activePhase)
            {
                return;
            }
            currentIngredients = new List<BaseIngredient>();
            for (int i = 0; i < choices; i++)
            {
                currentIngredients.Add(ingredientsLibrary.ReturnIngredient());
                DisplayChoices(i);
            }
            timer.StartTimer();
            TimerStartedEvent?.Invoke();
        }

        private void DisplayChoices(int index)
        {
            DisplayChoicesEvent?.Invoke(index, currentIngredients[index]);
        }

        public void AddIngredientToInventory(int index)
        {
            if (PlayerRef.AddToInventory(currentIngredients[index]))
            {
                SelectIngredients();
            }
            else
            {
                AskToChangePhase();
            }
        }

        private void AutoSelect()
        {
            int index = UnityEngine.Random.Range(0, currentIngredients.Count);
            {
                AddIngredientToInventory(index);
            }
        }
    }
}
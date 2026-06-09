using System;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.Events;

namespace Plate.Gameplay.Phases
{
    public class ChoicePhase : Phase
    {
        [SerializeField] private int choices;
        [SerializeField] private IngredientsLibrary ingredientsLibrary;
        
        private List<BaseIngredient> currentIngredients;
        
        public event System.Action<int,BaseIngredient> DisplayChoicesEvent; 
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("ChoicePhaseStart");
            SelectIngredients();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("ChoicePhaseEnd");
        }

        private void SelectIngredients()
        {
            currentIngredients = new List<BaseIngredient>();
            for (int i = 0; i < choices; i++)
            {
                currentIngredients.Add(ingredientsLibrary.ReturnIngredient());
                DisplayChoices(i);
            }
        }

        private void DisplayChoices(int index)
        {
            DisplayChoicesEvent?.Invoke(index, currentIngredients[index]);
        }

        public UnityAction AddIngredientToInventory(int index)
        {
            playerRef.AddToInventory(currentIngredients[index]);
            SelectIngredients();
            return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class EvaluationPhase : Phase
    {
        [SerializeField] private Plate plate;
        private List<BaseIngredient> ingredientsToCalculate;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("EvaluationPhaseStart");
            ingredientsToCalculate = plate.ReturnBaseIngredientsOnPlate();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("EvaluationPhaseEnd");
        }

        private void CalculateIngredientsOnlyScore()
        {
            int ingredientsScore = 0;
            foreach (BaseIngredient ingredient in ingredientsToCalculate)
            {
                int scoreToAdd = ingredient.CalculatePoints();
                ingredientsScore += scoreToAdd;
            }
        }
    }
}
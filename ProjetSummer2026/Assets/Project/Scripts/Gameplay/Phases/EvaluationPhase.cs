using System;
using System.Collections;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using Plate.Gameplay.Player;
using Plate.Gameplay.Skills;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plate.Gameplay.Phases
{
    public class EvaluationPhase : Phase
    {
        [SerializeField] private PlateRef plateRef;
        [SerializeField] private SkillsManager skillsManager;
        private List<BaseIngredient> ingredientsToCalculate;

        private int ingredientsOnlyScore;
        private int orderOnlyScore;
        private int skillsOnlyScore;
        private int totalScore;
        
        public event Action<List<BaseIngredient>,List<int>,int> OnIngredientsCalculated;
        public event Action<List<int>,int, int> OnOrderCalculated;
        public event Action<List<int>, int, int> OnSkillsCalculated; 
        public event Action<int> OnTotalCalculated; 
        public event Action<int> OnStarsCalculated;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("EvaluationPhaseStart");
            ingredientsToCalculate = plateRef.ReturnBaseIngredientsOnPlate();
            CalculateIngredientsOnlyScore();
            CalculateOrderOnlyScore();
            CalculateSkillsOnlyScore();
            CalculateTotalScore();
            CalculateStars();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("EvaluationPhaseEnd");
        }

        private void CalculateIngredientsOnlyScore()
        {
            List<BaseIngredient> calculatedIngredients = new List<BaseIngredient>();
            List<int> calculatedScores = new List<int>();
            ingredientsOnlyScore = 0;
            foreach (BaseIngredient ingredient in ingredientsToCalculate)
            {
                int scoreToAdd = ingredient.CalculatePoints(plateRef);
                calculatedScores.Add(scoreToAdd);
                calculatedIngredients.Add(ingredient);
                ingredientsOnlyScore += scoreToAdd;
            }
            OnIngredientsCalculated?.Invoke(calculatedIngredients, calculatedScores, ingredientsOnlyScore);
        }

        private void CalculateOrderOnlyScore()
        {
            orderOnlyScore = 0;
            List<int> pointsFromOrder = PhasePlayerRef.GetOrder().CalculatePoints(ingredientsToCalculate);
            foreach (int point in pointsFromOrder)
            {
                orderOnlyScore += point;
            }
            int additionalOrderScore = PhasePlayerRef.GetOrder().CalculateOverallAdditionalPoints(ingredientsToCalculate);
            orderOnlyScore += additionalOrderScore;
            OnOrderCalculated?.Invoke(pointsFromOrder, additionalOrderScore, orderOnlyScore);
        }

        private void CalculateSkillsOnlyScore()
        {
            skillsOnlyScore = 0;
            List<int> pointsFromSkills = skillsManager.CalculateSkillPointsForAllIngredients(ingredientsToCalculate);
            foreach (int point in pointsFromSkills)
            {
                skillsOnlyScore += point;
            }
            int additionalSkillsScore = skillsManager.CalculateSkillOverallAdditionnalPoints(ingredientsToCalculate);
            skillsOnlyScore += additionalSkillsScore;
            OnSkillsCalculated?.Invoke(pointsFromSkills, additionalSkillsScore, skillsOnlyScore);
        }

        private void CalculateTotalScore()
        {
            totalScore = ingredientsOnlyScore + orderOnlyScore + skillsOnlyScore;
            OnTotalCalculated?.Invoke(totalScore);
        }

        private void CalculateStars()
        {
            int stars = 0;
            for (int i = 0; i < PhasePlayerRef.GetGrade().pointsForStars.Length; i++)
            {
                if (totalScore >= PhasePlayerRef.GetGrade().pointsForStars[i])
                {
                    stars++;
                }
                else
                {
                    break;
                }
            }
            PhasePlayerRef.AddStars(stars);
            OnStarsCalculated?.Invoke(stars);
        }
    }
}
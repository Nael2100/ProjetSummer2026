using System;
using System.Collections;
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class EvaluationPhaseUI : PhaseUI
    {
        [SerializeField] private EvaluationPhase phase;
        [SerializeField] private Transform linesParent;
        [SerializeField] private GameObject linePrefab;
        [SerializeField] private OrderReminderUI orderReminderUI;
        [SerializeField] private EvaluationTotalUI evaluationTotalUI;
        [SerializeField] private EvaluationStarsUI evaluationStarsUI;
        
        private List<EvaluationLineUI> lines = new List<EvaluationLineUI>();
        private bool readyForOrderScore;
        private bool readyForTotalScore;
        private bool readyForSkills;
        private int wastedScoreMemo;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            phase.OnPhaseBeginEvent += SetUp;
            phase.OnIngredientsCalculated += DisplayIngredientsResults;
            phase.OnOrderCalculated += DisplayOrderResults;
            phase.OnSkillsCalculated += DisplaySkillsResults;
            phase.OnWastesCalculated += DisplayWastedScore;
            phase.OnTotalCalculated += DisplayTotalResults;
            phase.OnStarsCalculated += DisplayStars;
            phase.OnPhaseBeginEvent += ResetLines;
            evaluationStarsUI.OnStarsCompleted += SetButton;
        }

        private void SetUp(Phase phase)
        {
            orderReminderUI.DisplayOrderReminder(phase.GetCurrentOrder(), false, true);
        }
        private void ResetLines(Phase phase)
        {
            changePhaseButton.gameObject.SetActive(false);
            foreach (EvaluationLineUI line in lines)
            {
                line.ResetVisual();
                line.gameObject.SetActive(false);
            }
            readyForOrderScore = false;
            readyForTotalScore = false;
            readyForSkills = false;
            evaluationStarsUI.ReadyToDisplay(false);
            evaluationTotalUI.Reset();
        }

        private void DisplayIngredientsResults(List<BaseIngredient> ingredients, List<int> scores, int total)
        {
            StartCoroutine(DisplayIngredientsResultsOneByeOne(ingredients, scores, total));
        }

        private void DisplayTotalResults(int total)
        {
            StartCoroutine(DisplayTotalResultsOneByOne(total));
        }

        private void DisplayOrderResults(List<int> scores,  int additional, int total)
        {
            StartCoroutine(DisplayOrderResultsOneByeOne(scores, additional,total));
        }

        private void DisplaySkillsResults(List<int> scores, int additional, int total)
        {
            StartCoroutine(DisplaySkillsResultsOneByeOne(scores, additional, total));
        }

        IEnumerator DisplayIngredientsResultsOneByeOne(List<BaseIngredient> ingredients, List<int> scores, int total)
        {
            int i = 0;
            yield return new WaitForSeconds(0.5f);
            while (i < ingredients.Count)
            {
                if (i > lines.Count - 1)
                {
                    AddLine();
                    lines[i].ResetVisual();
                }
                lines[i].gameObject.SetActive(true);
                AdjustScroll(i);
                lines[i].DisplayEvaluationLineImage(ingredients[i]);
                i++;
                yield return new WaitForSeconds(0.5f);
            }

            i = 0;
            while (i < ingredients.Count)
            {
                if (i > lines.Count - 1)
                {
                    AddLine();
                }
                lines[i].DisplayEvaluationLineForIngredient(scores[i]);
                AdjustScroll(i);
                i++;
                yield return new WaitForSeconds(1f);
            }
            evaluationTotalUI.DisplayIngredientsOnlyScore(total);
            readyForOrderScore = true;
        }

        private void AdjustScroll(int index)
        {
            index++;
            Vector2 newScrollPosition;
            float unMoveSize = linesParent.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
            float spacing = linesParent.GetComponent<VerticalLayoutGroup>().spacing;
            newScrollPosition = new Vector2(0, (index * linePrefab.GetComponent<RectTransform>().sizeDelta.y) + (spacing*index-1) - unMoveSize);
            if (newScrollPosition.y <= 0)
            {
                newScrollPosition = Vector2.zero;
            }
            Debug.Log(newScrollPosition);
            linesParent.GetComponent<RectTransform>().anchoredPosition = newScrollPosition;
        }
        IEnumerator DisplayOrderResultsOneByeOne(List<int> scores,  int additional, int total)
        {
            while (!readyForOrderScore)
            {
                yield return new WaitForSeconds(0.5f);
            }
            int i = 0;
            yield return new WaitForSeconds(0.5f);
            while (i < scores.Count)
            {
                lines[i].DisplayEvaluationLineForOrder(scores[i]);
                AdjustScroll(i);
                i++;
                yield return new WaitForSeconds(1f);
            }
            evaluationTotalUI.DisplayOrderAdditionalScore(additional);
            yield return new WaitForSeconds(1f);
            evaluationTotalUI.DisplayOrderOnlyScore(total);
            readyForSkills = true;
        }

        IEnumerator DisplaySkillsResultsOneByeOne(List<int> scores, int additional, int total)
        {
            while (!readyForSkills)
            {
                yield return new WaitForSeconds(0.5f);
            }
            int i = 0;
            yield return new WaitForSeconds(0.5f);
            while (i < scores.Count)
            {
                lines[i].DisplayEvaluationLineForSkills(scores[i]);
                AdjustScroll(i);
                i++;
                yield return new WaitForSeconds(1f);
            }
            evaluationTotalUI.DisplaySkillsAdditionalScore(additional);
            yield return new WaitForSeconds(1f);
            evaluationTotalUI.DisplaySkillsOnlyScore(total);
            yield return new WaitForSeconds(1f);
            readyForTotalScore = true;
        }

        IEnumerator DisplayTotalResultsOneByOne(int total)
        {
            while (!readyForTotalScore)
            {
                yield return new WaitForSeconds(0.5f);
            }
            evaluationTotalUI.DisplayWastesScore(wastedScoreMemo);
            yield return new WaitForSeconds(1f);
            evaluationTotalUI.DisplayResultScore(total);
            evaluationStarsUI.ReadyToDisplay(true);
        }

        private void AddLine()
        {
            GameObject line = Instantiate(linePrefab, linesParent);
            lines.Add(line.GetComponent<EvaluationLineUI>());
            line.GetComponent<EvaluationLineUI>().ResetVisual();
        }

        private void DisplayStars(int amount)
        {
            evaluationStarsUI.DisplayStars(amount, phase.GetCurrentOrder().ReturnOrderClientData().reactionsToStars[amount]);
        }

        private void DisplayWastedScore(int amount)
        {
            wastedScoreMemo += amount;
        }
    }
}
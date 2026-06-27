using System;
using System.Collections;
using Plate.Core.Scriptable.Grade;
using Plate.Gameplay.Grades;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class RecapPhase : Phase
    {
        [SerializeField] private GradesManager gradesManager;
        public event Action<int, int, int, GradeData, string> OnDisplayInfos;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            StartCoroutine(DisplayAll());
        }

        IEnumerator DisplayAll()
        {
            yield return null;
            int starsQuantity = PhasePlayerRef.GetStars();
            int starsNeeded = gradesManager.ReturnStarsNeeded(PhasePlayerRef.GetGrade());
            int daysLeft = PhasePlayerRef.GetDaysLeft();
            GradeData currentGrade = PhasePlayerRef.GetGrade();
            string playerName = PhasePlayerRef.GetPlayerName();
            OnDisplayInfos?.Invoke(starsQuantity, starsNeeded, daysLeft, currentGrade, playerName);
        }
    }
}
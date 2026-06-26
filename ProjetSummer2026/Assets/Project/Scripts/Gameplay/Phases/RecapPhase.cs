using System;
using System.Collections;
using Plate.Gameplay.Grades;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class RecapPhase : Phase
    {
        [SerializeField] private GradesManager gradesManager;
        public event Action<int, int, int, Sprite, string> OnDisplayInfos;
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
            Sprite gradeSprite = PhasePlayerRef.GetGrade().gradeIcon;
            string playerName = PhasePlayerRef.GetPlayerName();
            OnDisplayInfos?.Invoke(starsQuantity, starsNeeded, daysLeft, gradeSprite, playerName);
        }
    }
}
using System;
using System.Collections;
using Plate.Core.Scriptable.Grade;
using Plate.Gameplay.Grades;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class GraduationPhase : Phase
    {
        [SerializeField] private GradesManager gradesManager;
        [SerializeField] private int daysToObtain;
        private GradeData currentGrade;
        private int daysLeft;

        protected override void Awake()
        {
            base.Awake();
            daysLeft = daysToObtain;
        }

        private void Start()
        {
            StartCoroutine(SetBaseGrade());
        }

        IEnumerator SetBaseGrade()
        {
            while (PhasePlayerRef == null)
            {
                yield return null;
            }
            PhasePlayerRef.SetGrade(gradesManager.ReturnFirstGrade());
            currentGrade = PhasePlayerRef.GetGrade();
        }

        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("GraduationPhaseStart");
            daysLeft--;
            currentGrade = PhasePlayerRef.GetGrade();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("GraduationPhaseEnd");
        }

        private void CheckGradeProgression()
        {
            int requiredStars = gradesManager.ReturnStarsNeeded(currentGrade);
            if (requiredStars > 0)
            {
                if (PhasePlayerRef.GetStars() >= requiredStars)
                {
                    PhasePlayerRef.SetGrade(gradesManager.ReturnNextGrade(currentGrade));
                    currentGrade = PhasePlayerRef.GetGrade();
                    daysLeft += daysToObtain;
                }
            }
        }
    }
}
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
        public event Action<int, GradeData, bool, int> OnProgressionChecked; 

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
            CheckGradeProgression();
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("GraduationPhaseEnd");
        }

        private void CheckGradeProgression()
        {
            int requiredStars = gradesManager.ReturnStarsNeeded(currentGrade);
            Debug.Log(requiredStars);
            if (requiredStars > 0)
            {
                if (PhasePlayerRef.GetStars() >= requiredStars)
                {
                    Debug.Log("gradeischanging");
                    PhasePlayerRef.SetGrade(gradesManager.ReturnNextGrade(currentGrade));
                    currentGrade = PhasePlayerRef.GetGrade();
                    daysLeft += daysToObtain;
                    OnProgressionChecked?.Invoke(PhasePlayerRef.GetStars(), currentGrade, true, daysLeft);
                }
                else
                {
                    OnProgressionChecked?.Invoke(PhasePlayerRef.GetStars(), gradesManager.ReturnNextGrade(currentGrade), false,daysLeft);
                }
            }
            
        }
    }
}
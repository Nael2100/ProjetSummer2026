using System;
using System.Collections;
using System.Collections.Generic;
using Plate.Core.Scriptable.Grade;
using Plate.Gameplay.Grades;
using Plate.Gameplay.Player;
using Plate.Gameplay.Save;
using Plate.Gameplay.Skills;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class GraduationPhase : Phase
    {
        [SerializeField] private GradesManager gradesManager;
        [SerializeField] private SkillsManager skillsManager;
        [SerializeField] private int daysToObtain;
        private GradeData currentGrade;
        private int daysLeft;
        public event Action<int, GradeData, bool, int> OnProgressionChecked;
        public event Action<GradeData, List<BaseSkill>, SkillsManager> OnSkillUpgrade;

        protected override void Awake()
        {
            base.Awake();
            daysLeft = SaveManager.Instance.daysLeft;
            currentGrade = gradesManager.ReturnDataFromTitle(SaveManager.Instance.playerGrade);
            skillsManager.AddSkillsFromTitle(SaveManager.Instance.playerSkills);
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
            PhasePlayerRef.SetDaysLeft(daysLeft);
            SetPlayerSkillsNames();
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
            SetPlayerSkillsNames();
            Debug.Log("GraduationPhaseEnd");
        }

        private void SetPlayerSkillsNames()
        {
            List<BaseSkill> baseSkills = skillsManager.GetSkills();
            int skillsCount = baseSkills.Count;
            string[] newSkills = new string[skillsCount];
            for (int i = 0; i < skillsCount; i++)
            {
                newSkills[i] = baseSkills[i].GetName();
            }
            PhasePlayerRef.SetSkills(newSkills);
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
                    PhasePlayerRef.UpgradeInventoryCapacity(currentGrade.inventorySIze);
                    OnProgressionChecked?.Invoke(PhasePlayerRef.GetStars(), currentGrade, true, daysLeft);
                }
                else
                {
                    OnProgressionChecked?.Invoke(PhasePlayerRef.GetStars(), gradesManager.ReturnNextGrade(currentGrade), false,daysLeft);
                }
            }
            PhasePlayerRef.SetDaysLeft(daysLeft);
        }

        public void SkillUpgrade()
        {
            OnSkillUpgrade?.Invoke(currentGrade, skillsManager.SelectSkills(), skillsManager);
        }
    }
}
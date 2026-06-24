using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Grade;
using Plate.Gameplay.Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class UpgradeScreenUI : MonoBehaviour
    {
        [SerializeField] private GraduationPhase phase;
        [SerializeField] private List<SkillChoiceUI> skillChoicesUI;
        [SerializeField] private TextMeshProUGUI newGradeText;
        [SerializeField] private Image newGradeImage;
        private void Awake()
        {
            phase.OnSkillUpgrade += DisplayUpgradeScreen;
            foreach (SkillChoiceUI skillChoice in skillChoicesUI)
            {
                skillChoice.OnSkillSelected += EndChoice;
            }
            gameObject.SetActive(false);
        }

        private void DisplayUpgradeScreen(GradeData newGrade, List<BaseSkill> skillsOptions, SkillsManager skillManager)
        {
            gameObject.SetActive(true);
            newGradeText.text = newGrade.gradeName;
            newGradeImage.sprite = newGrade.gradeIcon;
            for (int i = 0; i < skillChoicesUI.Count; i++)
            {
                if (i < skillsOptions.Count)
                {
                    skillChoicesUI[i].DisplayChoice(skillsOptions[i], skillManager);
                }
            }
        }

        public void EndChoice()
        {
            gameObject.SetActive(false);
        }
    }
}
using System;
using Plate.Gameplay.Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class SkillChoiceUI : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image skillImage;
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI skillDescription;
        public event Action OnSkillSelected;
        public void DisplayChoice(BaseSkill skill, SkillsManager skillsManager)
        {
            skillImage.sprite = skill.GetIcon();
            skillName.text = skill.GetName();
            skillDescription.text = skill.GetDescription();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnSkillSelectedCall);
            button.onClick.AddListener(() => skillsManager.ObtainSkill(skill));
        }

        public void OnSkillSelectedCall()
        {
            OnSkillSelected?.Invoke();
        }
    }
}
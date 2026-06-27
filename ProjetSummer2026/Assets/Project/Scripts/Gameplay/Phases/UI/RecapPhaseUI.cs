using Plate.Core.Scriptable.Grade;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class RecapPhaseUI : PhaseUI
    {
        [SerializeField] private RecapPhase phase;
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI playerScoreText;
        [SerializeField] private TextMeshProUGUI playerObjectiveText;
        [SerializeField] private TextMeshProUGUI playerGradeText;
        [SerializeField] private Image playerGradeImage;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            SetButton();
            phase.OnDisplayInfos += DisplayInfos;
        }

        private void DisplayInfos(int starsQuantity, int starsNeeded, int daysLeft, GradeData currentGrade, string playerName)
        {
            SetButton();
            playerNameText.text = playerName;
            playerScoreText.text = starsQuantity.ToString();
            playerObjectiveText.text = daysLeft.ToString() + " Days left to obtain " + starsNeeded.ToString() + " stars";
            playerGradeImage.sprite = currentGrade.gradeIcon;
            playerGradeText.text = currentGrade.gradeName;
        }
    }
}
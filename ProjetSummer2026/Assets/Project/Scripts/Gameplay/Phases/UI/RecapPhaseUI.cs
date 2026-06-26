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
        [SerializeField] private Image playerGradeImage;

        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            SetButton();
            phase.OnDisplayInfos += DisplayInfos;
        }

        private void DisplayInfos(int starsQuantity, int starsNeeded, int daysLeft, Sprite nextGrade)
        {
            SetButton();
            playerNameText.text = "Chef";
            playerScoreText.text = starsQuantity.ToString();
            playerObjectiveText.text = daysLeft.ToString() + " Days left to obtain " + starsNeeded.ToString() + " stars";
            playerGradeImage.sprite = nextGrade;
            
        }
    }
}
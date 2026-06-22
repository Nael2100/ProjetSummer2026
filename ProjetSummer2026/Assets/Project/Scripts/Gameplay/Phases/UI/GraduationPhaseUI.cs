using System.Collections;
using Plate.Core.Scriptable.Grade;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class GraduationPhaseUI : PhaseUI
    {
        [SerializeField] private GraduationPhase phase;
        [SerializeField] private Image progressImage;
        [SerializeField] private TextMeshProUGUI starsCountText;
        [SerializeField] private TextMeshProUGUI nextGradeText;
        [SerializeField] private Image nextGradeImage;

        private int daysLeft;
        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            progressImage.fillAmount = 0f;
            phase.OnProgressionChecked += DisplayProgress;
        }

        private void DisplayProgress(int currentStars, GradeData nextGrade, bool newGrade, int newDaysLeft)
        {
            daysLeft = newDaysLeft;
            if (newGrade)
            {
                StartCoroutine(ProgressBar(1f, true, nextGrade, (float)currentStars/(float)nextGrade.requiredStarsToObtain));
            }
            else
            {
                Debug.Log(currentStars+ "/" +nextGrade.requiredStarsToObtain);
                StartCoroutine(ProgressBar((float)currentStars/(float)nextGrade.requiredStarsToObtain));
                DisplayNextGrade(nextGrade);
            }
            starsCountText.text = currentStars.ToString();
        }

        IEnumerator ProgressBar(float progress, bool newGrade=false, GradeData newGradeData=null, float newProgress=0)
        {
            Debug.Log("Porco rosse: " + progress);
            while (progressImage.fillAmount < progress)
            {
                progressImage.fillAmount += Time.deltaTime*0.1f;
                yield return null;
            }
            progressImage.fillAmount = progress;
            if (newGrade)
            {
                progressImage.fillAmount = 0;
                DisplayNextGrade(newGradeData);
                StartCoroutine(ProgressBar(newProgress));
            }
            else
            {
                SetButton();
            }
        }

        private void DisplayNextGrade(GradeData nextGrade)
        {
            nextGradeImage.sprite = nextGrade.gradeIcon;
            nextGradeText.text = daysLeft.ToString() + " Days left ";
        }
    }
}
using System;
using System.Collections;
using Plate.Gameplay.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Plate.Gameplay.Phases.UI
{
    public class ChoiceTimerUI : MonoBehaviour
    {
        [SerializeField] private Image timerImage;
        [SerializeField] private ChoicePhaseTimer phase;

        private void Awake()
        {
            phase.OnTimerEnd += EndTimer;
            phase.OnTimerUpdate += UpdateTimer;
            timerImage.gameObject.SetActive(false);
        }

        public void StartTimer()
        {
            Debug.Log("StartTimer");
            timerImage.gameObject.SetActive(true);
            timerImage.fillAmount = 1f;
        }

        public void EndTimer()
        {
            Debug.Log("EndTimer");
        }

        private void UpdateTimer(bool active, float value)
        {
            if (active)
            {
                timerImage.fillAmount = value;
            }
            if (value <= 0)
            {
                EndTimer();
            }
        }
    }
}
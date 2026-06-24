using System;
using System.Collections;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class ChoicePhaseTimer : MonoBehaviour
    {
                
        public event Action<bool> OnTimerEnd;
        public event Action<bool,float> OnTimerUpdate;
        
        private bool timerActive;
        private float leftTime;
        private float timerDuration;
        
        
        public void StartTimer(float duration)
        {
            SetUpTimer(duration);
            timerActive = true;
            StopAllCoroutines();
            StartCoroutine(Timer());
        }

        private void SetUpTimer(float duration)
        {
            timerDuration = duration;
            leftTime = timerDuration;
        }

        public void StopTimer()
        {
            timerActive = false;
        }

        IEnumerator Timer()
        {
            while (leftTime > 0 && timerActive)
            {
                leftTime -= Time.deltaTime;
                OnTimerUpdate?.Invoke(timerActive, leftTime/timerDuration);
                yield return null;
            }
            OnTimerEnd?.Invoke(timerActive);
        }
    }
}
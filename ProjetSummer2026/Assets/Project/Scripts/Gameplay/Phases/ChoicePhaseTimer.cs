using System;
using System.Collections;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class ChoicePhaseTimer : MonoBehaviour
    {
                
        public event Action OnTimerEnd;
        public event Action<bool,float> OnTimerUpdate;
        
        private bool timerActive;
        private float leftTime;
        private float timerDuration;
        
        
        public void StartTimer()
        {
            SetUpTimer();
            timerActive = true;
            StopAllCoroutines();
            StartCoroutine(Timer());
        }

        private void SetUpTimer()
        {
            
            timerDuration = PlayerRef.instance.ReturnChoiceTimerDuration();
            leftTime = timerDuration;
        }

        IEnumerator Timer()
        {
            while (leftTime > 0 && timerActive)
            {
                leftTime -= Time.deltaTime;
                OnTimerUpdate?.Invoke(timerActive, leftTime/timerDuration);
                yield return null;
            }
            OnTimerEnd?.Invoke();
        }
    }
}
using System;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class Phase : MonoBehaviour
    {
        [SerializeField] private GameObject phaseUI;
        
        public event Action<Phase> OnPhaseBeginEvent; 
        public event Action<Phase> OnPhaseEndEvent;

        protected Player.Player playerRef;
        protected private void Awake()
        {
            phaseUI.SetActive(false);
            //playerRef = Player.Player.instance;
        }

        public virtual void OnPhaseBegin()
        {
            OnPhaseBeginEvent?.Invoke(this);
            phaseUI.SetActive(true);
        }

        public virtual void OnPhaseEnd()
        {
            OnPhaseEndEvent?.Invoke(this);
            phaseUI.SetActive(false);
        }
    }
}
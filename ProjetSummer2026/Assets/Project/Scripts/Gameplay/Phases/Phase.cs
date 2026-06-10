using System;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class Phase : MonoBehaviour
    {
        [SerializeField] private GameObject phaseUI;
        
        public event Action<Phase> OnPhaseBeginEvent; 
        public event Action<Phase> OnPhaseEndEvent;
        
        public virtual event Action<Phase> AskToChangePhaseEvent;

        protected Player.PlayerRef PlayerRef;
        private protected void Start()
        {
            phaseUI.SetActive(false);
            PlayerRef = PlayerRef.instance;
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

        protected void AskToChangePhase()
        {
            AskToChangePhaseEvent?.Invoke(this);
        }
    }
}
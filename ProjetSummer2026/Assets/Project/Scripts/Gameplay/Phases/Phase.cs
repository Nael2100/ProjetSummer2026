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

        protected PlayerRef PhasePlayerRef;
        protected bool activePhase;
        protected virtual void Awake()
        {
            phaseUI.SetActive(false);
        }

        public void SetPlayerRef(PlayerRef newRef, PhaseManager managerCheck)
        {
            PhasePlayerRef = newRef;
        }
        public virtual void OnPhaseBegin()
        {
            activePhase = true;
            OnPhaseBeginEvent?.Invoke(this);
            phaseUI.SetActive(true);
        }

        public virtual void OnPhaseEnd()
        {
            activePhase = false;
            OnPhaseEndEvent?.Invoke(this);
            phaseUI.SetActive(false);
        }

        protected void AskToChangePhase()
        {
            AskToChangePhaseEvent?.Invoke(this);
        }
    }
}
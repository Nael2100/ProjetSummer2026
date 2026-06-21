using System;
using System.Collections.Generic;
using Plate.Gameplay.Player;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PhaseManager : MonoBehaviour
    {
        [SerializeField] private PlayerRef player;
        [SerializeField] private List<Phase> phasesInOrder;
        private int CurrentPhaseIndex = 0;
        private Phase CurrentPhase;

        private void Start()
        {
            CurrentPhaseIndex = 0;
            CurrentPhase = phasesInOrder[CurrentPhaseIndex];
            foreach (Phase phase in phasesInOrder)
            {
                phase.AskToChangePhaseEvent += CheckCanChangePhase;
                phase.SetPlayerRef(player,this);
            }
            CurrentPhase.OnPhaseBegin();
        }

        private void NextPhase()
        {
            CurrentPhase.OnPhaseEnd();
            CurrentPhaseIndex += 1;
            if (CurrentPhaseIndex >= phasesInOrder.Count)
            {
                CurrentPhaseIndex = 0;
            }
            CurrentPhase = phasesInOrder[CurrentPhaseIndex];
            CurrentPhase.OnPhaseBegin();
        }

        public void CheckCanChangePhase(Phase phase)
        {
            if (CurrentPhase == phase)
            {
                NextPhase();
            }
        }
    }
}

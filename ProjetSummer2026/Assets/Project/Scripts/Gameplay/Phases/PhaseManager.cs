using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PhaseManager : MonoBehaviour
    {
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
            }
            CurrentPhase.OnPhaseBegin();
        }

        public void NextPhase()
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

        private void CheckCanChangePhase(Phase phase)
        {
            if (CurrentPhase == phase)
            {
                NextPhase();
            }
        }
    }
}

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

        private void Awake()
        {
            CurrentPhaseIndex = 0;
            CurrentPhase = phasesInOrder[CurrentPhaseIndex];
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
    }
}

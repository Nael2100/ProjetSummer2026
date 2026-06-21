using UnityEngine;

namespace Plate.Gameplay.Phases.UI
{
    public class GraduationPhaseUI : PhaseUI
    {
        [SerializeField] private GraduationPhase phase;
        protected override void Awake()
        {
            base.Awake();
            basephase = phase;
            SetButton();
        }
    }
}
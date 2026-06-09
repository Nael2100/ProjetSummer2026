using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class GraduationPhase : Phase
    {
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("GraduationPhaseStart");
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("GraduationPhaseEnd");
        }
    }
}
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class DressingPhase : Phase
    {
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("DressingPhaseStart");
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("DressingPhaseEnd");
        }
    }
}
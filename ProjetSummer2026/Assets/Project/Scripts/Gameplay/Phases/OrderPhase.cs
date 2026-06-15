using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class OrderPhase : Phase
    {
        
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("OrderPhaseStart");
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("OrderPhaseEnd");
        }
    }
}
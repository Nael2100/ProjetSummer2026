using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class EvaluationPhase : Phase
    {
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("EvaluationPhaseStart");
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("EvaluationPhaseEnd");
        }
    }
}
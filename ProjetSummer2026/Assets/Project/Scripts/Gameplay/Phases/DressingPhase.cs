using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Ingredients;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plate.Gameplay.Phases
{
    public class DressingPhase : Phase
    {
        [FormerlySerializedAs("plate")] [SerializeField] private PlateRef plateRef;
        public event Action<List<BaseIngredient>> OnDisplayInventory;
        public event Action<List<BaseIngredient>> OnUndisplayInventory;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("DressingPhaseStart");
            foreach (PlateSlot slot in plateRef.GetSlots())
            {
                slot.ResetOccupation();
                foreach (BaseIngredient ingredient in PhasePlayerRef.GetInventory())
                {
                    ingredient.SetSlot(slot);
                }
            }
            OnDisplayInventory?.Invoke(PhasePlayerRef.GetInventory());
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("DressingPhaseEnd");
            OnUndisplayInventory?.Invoke(PhasePlayerRef.GetInventory());
        }
    }
}
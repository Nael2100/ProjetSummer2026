using System;
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class DressingPhase : Phase
    {
        [SerializeField] private Plate plate;
        public override void OnPhaseBegin()
        {
            base.OnPhaseBegin();
            Debug.Log("DressingPhaseStart");
            foreach (PlateSlot slot in plate.GetSlots())
            {
                foreach (BaseIngredient ingredient in PlayerRef.GetInventory())
                {
                    ingredient.SetSlot(slot);
                }
            }
        }

        public override void OnPhaseEnd()
        {
            base.OnPhaseEnd();
            Debug.Log("DressingPhaseEnd");
        }
    }
}
using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PlateSlot : MonoBehaviour
    {
        [SerializeField] private List<PlateSlot> neighbors = new List<PlateSlot>();
        protected BaseIngredient currentIngredient;
        protected bool occupied = false;

        public void ResetOccupation()
        {
            occupied = false;
        }
        public bool ReturnSnap(Vector2 pos)
        {
            if (!occupied)
            {
                if (Vector2.Distance(transform.position, pos) < 40f)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void SetIngredient(BaseIngredient newIngredient, bool add)
        {
            if (add)
            {
                if (!occupied)
                {
                    occupied = true;
                    currentIngredient = newIngredient;
                }
            }
            else
            {
                occupied = false;
                currentIngredient = null;
            }
        }

        public BaseIngredient ReturnIngredient()
        {
            return currentIngredient;
        }
    }
}
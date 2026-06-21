using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PlateSlot : MonoBehaviour
    {
        private BaseIngredient ingredient;
        private bool occupied = false;

        public void ResetOccupation()
        {
            occupied = false;
        }
        public bool ReturnSnap(Vector2 pos)
        {
            if (!occupied)
            {
                if (Vector2.Distance(transform.position, pos) < 20f)
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
                    ingredient = newIngredient;
                }
            }
            else
            {
                occupied = false;
                ingredient = null;
            }
        }

        public BaseIngredient ReturnIngredient()
        {
            return ingredient;
        }
    }
}
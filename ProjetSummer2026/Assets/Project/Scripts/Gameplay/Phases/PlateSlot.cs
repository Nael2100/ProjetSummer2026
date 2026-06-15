using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class PlateSlot : MonoBehaviour
    {
        public bool ReturnSnap(Vector2 pos)
        {
            Debug.Log(Vector2.Distance(transform.position, pos));
            if (Vector2.Distance(transform.position, pos) < 20f)
            {
                
                return true;
            }
            return false;
        }
    }
}
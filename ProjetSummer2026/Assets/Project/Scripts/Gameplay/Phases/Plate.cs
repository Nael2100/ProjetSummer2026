using System.Collections.Generic;
using UnityEngine;

namespace Plate.Gameplay.Phases
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private List<PlateSlot> plateSlots;

        public List<PlateSlot> GetSlots()
        {
            return plateSlots;
        }
    }
}
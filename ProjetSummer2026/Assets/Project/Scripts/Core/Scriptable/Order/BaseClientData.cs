using UnityEngine;

namespace Plate.Core.Scriptable.Order
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Order/Client/BaseClientData", order = 0)]
    public class BaseClientData : ScriptableObject
    {
        [field: SerializeField] 
        public string clientName { get; private set; }
        [field: SerializeField] 
        public Sprite clientIcon { get; private set; }
        [field: SerializeField]
        public string[] reactionsToStars { get; private set; }
    }
}
using UnityEngine;
using UnityEngine.Serialization;

namespace Plate.Core.Scriptable.Player
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Player/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public int inventorySize = 4;
        public float choiceTime = 5f;
        public int malusForWaste = -1;
    }
}
using UnityEngine;

namespace Plate.Core.Scriptable.Grade
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Grade/GradeData", order = 0)]
    public class GradeData : ScriptableObject
    {
        [field: SerializeField]
        public string gradeName {get; private set;}
        [field: SerializeField]
        public Sprite gradeIcon {get; private set;}
        [field: SerializeField]
        public int requiredStarsToObtain {get; private set;}
        [field: SerializeField]
        public int[] pointsForStars {get; private set;}
        [field: SerializeField]
        public int inventorySIze {get; private set;}
    }
}
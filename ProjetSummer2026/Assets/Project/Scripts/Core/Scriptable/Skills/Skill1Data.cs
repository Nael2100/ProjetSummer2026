using UnityEngine;

namespace Plate.Core.Scriptable.Skills
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Skills/Skill1Data", order = 0)]
    public class Skill1Data : BaseSkillData
    {
        [field: SerializeField]
        public int pointForGardenIngredients {get; private set;}
    }
}
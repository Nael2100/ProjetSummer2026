using System.Collections.Generic;
using UnityEngine;

namespace Plate.Core.Scriptable
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Skills/BaseSkillData", order = 0)]
    public class BaseSkillData : ScriptableObject
    {
        [field: SerializeField]
        public string skillName {get; private set;}
        [field: SerializeField]
        public Sprite icon {get; private set;}
        [field: SerializeField]
        public string description {get; private set;}
        
    }
}
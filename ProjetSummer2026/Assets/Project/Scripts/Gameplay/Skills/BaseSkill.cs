using System.Collections.Generic;
using Plate.Core.Scriptable;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Skills
{
    public abstract class BaseSkill : MonoBehaviour
    {
        [SerializeField] protected BaseSkillData dataRef;

        public Sprite GetIcon()
        {
            return dataRef.icon;
        }

        public string GetName()
        {
            return dataRef.skillName;
        }

        public string GetDescription()
        {
            return dataRef.description;
        }
        public abstract int CalculatePoints(BaseIngredient ingredient);
        public abstract int CalculateOverallAdditionalPoints(List<BaseIngredient> ingredients);
    }
}
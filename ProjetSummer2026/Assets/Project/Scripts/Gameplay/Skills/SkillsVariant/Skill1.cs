using System.Collections.Generic;
using System.Linq;
using Plate.Core.Scriptable.Ingredients;
using Plate.Core.Scriptable.Skills;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Skills.SkillsVariant
{
    public class Skill1 : BaseSkill
    {
        public override int CalculatePoints(BaseIngredient ingredient)
        {
            if (dataRef is Skill1Data variantData)
            {
                if (ingredient.GetTypes().Contains(IngredientsTypes.Garden))
                {
                    return variantData.pointForGardenIngredients;
                }
            }
            return 0;
        }

        public override int CalculateOverallAdditionalPoints(List<BaseIngredient> ingredients)
        {
            return 0;
        }
    }
}
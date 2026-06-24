using System.Collections.Generic;
using Plate.Gameplay.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Skills
{
    public class SkillsManager : MonoBehaviour
    {
        [SerializeField] private List<BaseSkill> availableSkills = new List<BaseSkill>();
        [SerializeField] private int skillsChoices = 3;
        private List<BaseSkill> playerSkills = new List<BaseSkill>();

        public void ObtainSkill(BaseSkill skill)
        {
            playerSkills.Add(skill);
        }

        public List<BaseSkill> GetSkills()
        {
            return playerSkills;
        }

        public List<BaseSkill> SelectSkills()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!playerSkills.Contains(transform.GetChild(i).gameObject.GetComponent<BaseSkill>()))
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
            List<BaseSkill> selectedSkills = new List<BaseSkill>();
            for (int i = 0; i < skillsChoices; i++)
            {
                BaseSkill newSkill = availableSkills[Random.Range(0, availableSkills.Count)];
                GameObject newSkillObj = Instantiate(newSkill.gameObject, transform);
                newSkillObj.transform.SetParent(transform);
                selectedSkills.Add(newSkill);
            }
            return selectedSkills;
        }

        public List<int> CalculateSkillPointsForAllIngredients(List<BaseIngredient> ingredients)
        {
            List<int> points = new List<int>();
            for (int i = 0; i < ingredients.Count; i++)
            {
                int newScore = 0;
                points.Add(0);
                foreach (BaseSkill skill in playerSkills)
                {
                    newScore += skill.CalculatePoints(ingredients[i]);
                }
                points[i] += newScore;
            }
            return points;
        }

        public int CalculateSkillOverallAdditionnalPoints(List<BaseIngredient> ingredients)
        {
            int points = 0;
            foreach (BaseSkill skill in playerSkills)
            {
                points += skill.CalculateOverallAdditionalPoints(ingredients);
            }
            return points;
        }
    }
}
using System.Collections.Generic;
using Plate.Core.Scriptable.Grade;
using UnityEngine;

namespace Plate.Gameplay.Grades
{
    public class GradesManager : MonoBehaviour
    {
        [SerializeField] private List<GradeData> grades;

        public GradeData ReturnFirstGrade()
        {
            return grades[0];
        }

        public int ReturnStarsNeeded(GradeData grade)
        {
            for (int i = 0; i < grades.Count-1; i++)
            {
                if (grades[i] == grade)
                {
                    return grades[i + 1].requiredStarsToObtain;
                }
            }
            return 0;
        }

        public GradeData ReturnNextGrade(GradeData grade)
        {
            return grades[grades.IndexOf(grade)+1];
        }
    }
}
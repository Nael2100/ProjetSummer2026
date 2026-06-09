using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Ingredients
{
    public class IngredientsLibrary : MonoBehaviour
    {
        [SerializeField] List<BaseIngredient> IngredientsList;

        public BaseIngredient ReturnIngredient()
        {
            if (IngredientsList != null)
            {
                return IngredientsList[Random.Range(0, IngredientsList.Count)];
            }
            return null;
        }
    }
}
using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Ingredients
{
    public class IngredientsLibrary : MonoBehaviour
    {
        [SerializeField] List<BaseIngredient> IngredientsList;
        private List<BaseIngredient> SpawnedIngredients = new List<BaseIngredient>();

        public BaseIngredient ReturnIngredient()
        {
            if (IngredientsList != null)
            {
                GameObject newIngredient = Instantiate(IngredientsList[Random.Range(0, IngredientsList.Count)].gameObject, transform);
                newIngredient.name = newIngredient.GetComponent<BaseIngredient>().ReturnName();
                SpawnedIngredients.Add(newIngredient.GetComponent<BaseIngredient>());
                return newIngredient.GetComponent<BaseIngredient>();
            }
            return null;
        }

        public void ClearIngredients()
        {
            foreach (BaseIngredient ingredient in SpawnedIngredients)
            {
                Destroy(ingredient.gameObject);
            }
        }
    }
}
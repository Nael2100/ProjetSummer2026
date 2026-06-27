using System.Collections.Generic;
using Plate.Core.Scriptable.Ingredients;
using UnityEngine;
using UnityEngine.UI;

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
                BaseIngredient newIngredientToAdd = newIngredient.GetComponent<BaseIngredient>();
                newIngredient.GetComponent<Image>().sprite = newIngredientToAdd.ReturnImage();
                SpawnedIngredients.Add(newIngredientToAdd);
                return newIngredient.GetComponent<BaseIngredient>();
            }
            return null;
        }

        public void ClearIngredients()
        {
            foreach (BaseIngredient ingredient in SpawnedIngredients)
            {
                if (ingredient.gameObject != null)
                {
                    Destroy(ingredient.gameObject);
                }
            }
            SpawnedIngredients = new List<BaseIngredient>();
        }
    }
}
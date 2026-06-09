using Plate.Core.Scriptable.Ingredients;
using UnityEngine;

namespace Plate.Gameplay.Ingredients
{
    public class BaseIngredient : MonoBehaviour
    {
        [SerializeField] private BaseIngredientData dataRef;

        public Sprite ReturnImage()
        {
            return dataRef.sprite;
        }
    }
}
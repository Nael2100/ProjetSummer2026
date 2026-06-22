using UnityEngine;

namespace Plate.Core.Scriptable.Ingredients
{
    [CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Plate/Ingredients/BaseIngredientData")]
    public class BaseIngredientData : ScriptableObject
    {
        [field: SerializeField]
        public string ingredientName {get; private set;}
        [field: SerializeField]
        public string description {get; private set;}
        [field: SerializeField]
        public Sprite sprite {get; private set;}
        
        [field : SerializeField]
        public IngredientsTypes[] types {get; private set;}
        [field : SerializeField]
        public TasteValue[] tasteValues {get; private set;}
        
    }
}

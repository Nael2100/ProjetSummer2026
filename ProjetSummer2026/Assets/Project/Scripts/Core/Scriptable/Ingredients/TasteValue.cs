using UnityEngine;

namespace Plate.Core.Scriptable.Ingredients
{
    [System.Serializable]
    public class TasteValue
    {
        [field: SerializeField]
        public IngredientsTastes taste { get; private set; }
        [field: SerializeField]
        public int amount { get; private set; }
    }
}
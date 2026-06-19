using System.Collections.Generic;
using UnityEngine;

namespace Plate.Core.Scriptable.Order
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Plate/Order/BaseOrderData", order = 0)]
    public class BaseOrderData : ScriptableObject
    {
        [field : SerializeField]
        public string Title {get; private set;}
        [field : SerializeField]
        public string Description {get; private set;}
        [field : SerializeField]
        public List<string> Effects {get; private set;}
    }
}
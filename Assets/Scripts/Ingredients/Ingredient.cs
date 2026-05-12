using UnityEngine;
using System.Collections.Generic;

[]
public class IngredientData : ScriptableObject {
    [SerializeField] private string name;

    [HideInInspector] public string Name => name;
}

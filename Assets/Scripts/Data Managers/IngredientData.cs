using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public enum IngredientType { FizzyDrink = 0, Coffee = 1 };


[CreateAssetMenu(fileName = "Data", menuName = "Data/Ingredients")]
public class IngredientsData : ScriptableObject {

    [SerializeField] IngredientType type;
    [SerializeField] List<ContainerData> data;

    public List<ContainerData> Data => data;
    public IngredientType Type => type;
}

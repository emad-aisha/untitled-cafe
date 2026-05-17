using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Ingredients")]
public class IngredientsData : ScriptableObject {
    public enum IngredientType { FizzyDrink = 0, Coffee = 1 };

    [SerializeField] IngredientType type;
    [SerializeField] List<ContainerData> data;

    public List<ContainerData> Data => data;
    public IngredientType Type => type;
}

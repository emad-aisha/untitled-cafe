using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Ingredients")]
public class IngredientsData : ScriptableObject {
    [SerializeField] List<ContainerData> data;

    public List<ContainerData> Data => data;
}

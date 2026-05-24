using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ContainerData {
    public string name;
    public List<IngredientData> ingredients;
}


[Serializable]
public class IngredientData {
    public string name;
    public bool value;
}

[Serializable]
public class ListWrapper {
    [SerializeField] public List<bool> data = new();
}

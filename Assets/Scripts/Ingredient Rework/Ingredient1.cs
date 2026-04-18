using System.Collections.Generic;
using UnityEngine;

public struct Ingredient1 {
    public int priority;
    public Dictionary<string, bool> values;


    public void SetPriority(int newPriority) { priority = newPriority; }
}


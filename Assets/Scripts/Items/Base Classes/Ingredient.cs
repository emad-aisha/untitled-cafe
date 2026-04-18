using System;
using UnityEngine;

public class Ingredient {
    // TODO: find a way to make this show up in inspector
    // needs an enum to work
    Priorities priority;
    bool[] states;
    int max;

    // TODO: cleanup
    public Ingredient(int numOfStates, Priorities _priority) {
        states = new bool[numOfStates];
        SetAllStates(false);
        priority = _priority;
        max = numOfStates;
    }

    public bool SetIngredient(ref Ingredient input, ref int priority) {
        if (!CanChangeVariables(input) || !input.SetState(GetActiveStateIndex(), true)) return false;
        priority++;

        return true;
    }

    public bool CanChangeVariables(Ingredient ingredient) { return ingredient != null && !ingredient.IsActive(); }
    public bool CanChangeVariables() { return this != null && !IsActive(); }

    public bool IsActive() {
        foreach (bool state in states) if (state) return true;
        return false;
    }

    // getters 
    public Priorities GetPriority() { return priority; }
    public int GetMax() { return max; }
    public bool[] GetStates() { return states; }

    // get actives
    public bool GetStateValue<T>(T index) where T : Enum { return states.At(index); }
    public bool GetActiveState() {
        for (int i = 0; i < states.Length; i++) { if (states[i]) return true; }
        return false;
    }
    public int GetActiveStateIndex() {
        for (int i = 0; i < states.Length; i++) { if (states[i]) return i; }
        return -1;
    }

    // setters
    public bool SetState<T>(T index, bool inputBool) where T : Enum { states.At(index) = inputBool; return true; }
    public bool SetState(int index, bool inputBool) {
        if (index < 0 || index >= states.Length) { Debug.Log("index is out of range"); return false; }
        states[index] = inputBool; return true;
    }

    public void SetAllStates(bool state = false) { for (int i = 0; i < states.Length; i++) states[i] = state; }
}

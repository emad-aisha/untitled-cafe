using UnityEngine;

public class Ingredient {
    // needs an enum to work
    Priorities priority;
    bool[] states;


    public Ingredient(int numOfStates, Priorities _priority) {
        states = new bool[numOfStates];
        InitializeStates(numOfStates);
        priority = _priority;
    }

    public bool SetIngredient(ref Ingredient input, ref int priority) {
        if (!CanChangeVariables(input) || !input.SetState(GetStateIndex(), true)) return false;
        priority++;

        return true;
    }

    public bool CanChangeVariables(Ingredient ingredient) { return ingredient != null && ingredient.CanGetItem(); }
    public bool CanChangeVariables() { return this != null && CanGetItem(); }
    bool CanGetItem() { return IsAllOff(); }


    // viewers
    public bool IsAllOff() {
        for (int i = 0; i < states.Length; i++)
            if (states[i] == true) return false;
        return true;
    }

    // getters 
    public Priorities GetPriority() { return priority; }
    public int GetStateIndex() {
        for (int i = 0; i < states.Length; i++) {
            if (states[i]) return i;
        }
        Debug.Log("Ingredients: No state set to true");
        return -1;
    }
    public bool GetState(int index) {
        if (index < 0 || index >= states.Length) {
            Debug.Log("Error Getting State");
            return false;
        }
        return states[index];
    }

    public bool GetAnyState() {
        for (int i = 0; i < states.Length; i++) {
            if (states[i]) return true;
        }
        return false;
    }
    public int GetAnyStateIndex() {
        for (int i = 0; i < states.Length; i++) {
            if (states[i]) return i;
        }
        return -1;
    }

    // setters
    // TODO: add catch statements (basically, if error, print in debug.log)
    void InitializeStates(int numOfStates) { for (int i = 0; i < numOfStates; i++) states[i] = false; }
    public bool SetState(int index, bool inputBool) {
        if (index < 0 || index >= states.Length) return false;
        states[index] = inputBool;
        return true;
    }
    public void SetAllStates(bool state = false) { for (int i = 0; i < states.Length; i++) states[i] = state; }
}

using UnityEngine;

public class Ingredient {
    // needs an enum to work
    Priorities priority;
    bool[] states;
    int max;

    public Ingredient this[FizzyDrinkIngredients index] { get => this[index]; set => this[index] = value; }
    public Ingredient this[CoffeeIngredients index] { get => this[index]; set => this[index] = value; }

    // TODO: cleanup
    public Ingredient(int numOfStates, Priorities _priority, int _max) {
        states = new bool[numOfStates];
        InitializeStates(numOfStates);
        priority = _priority;
        max = _max;
    }

    public bool SetIngredient(ref Ingredient input, ref int priority) {
        if (!CanChangeVariables(input) || !input.SetState(GetStateIndex(), true)) return false;
        priority++;

        return true;
    }

    public bool CanChangeVariables(Ingredient ingredient) { return ingredient != null && ingredient.CanGetItem(); }
    public bool CanChangeVariables() { return this != null && CanGetItem(); }
    bool CanGetItem() { return IsAllOff(); }

    public bool IsAllOff() {
        for (int i = 0; i < states.Length; i++)
            if (states[i] == true) return false;
        return true;
    }

    // getters 
    public Priorities GetPriority() { return priority; }
    public int GetMax() { return max; }
    public int GetStateIndex() {
        for (int i = 0; i < states.Length; i++) if (states[i]) return i;
        Debug.Log("Ingredients: No state set to true"); return -1;
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
    void InitializeStates(int numOfStates) { for (int i = 0; i < numOfStates; i++) states[i] = false; }
    public bool SetState(int index, bool inputBool) {
        if (index < 0 || index >= states.Length) { Debug.Log("index too high or low"); return false; }
        states[index] = inputBool; return true;
    }
    public void SetAllStates(bool state = false) { for (int i = 0; i < states.Length; i++) states[i] = state; }
}

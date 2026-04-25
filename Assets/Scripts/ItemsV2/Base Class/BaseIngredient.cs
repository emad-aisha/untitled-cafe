using UnityEngine;

public class BaseIngredient : MonoBehaviour, IInteractable {
    public Container baseIngredient;
    public Data[] data;
    int ingIndex = 0;

    protected virtual void SetMemberVariables(string name) {
        SetIngredients();
        baseIngredient = new Container(name);
        baseIngredient.ingredient = data;
    }
    protected virtual void SetIngredients() { }
    protected virtual void SetData(string name, Priority priority, Ingredient[] ingredient) {
        data[ingIndex] = new Data(name, (int)priority);
        data[ingIndex].type = ingredient;
        ingIndex++;
    }
}

using UnityEngine;

public class BaseIngredient : MonoBehaviour, IInteractable {
    public Container baseIngredient;
    public IngredientType[] data;
    protected int ingIndex = 0;

    protected virtual void SetMemberVariables(string name) {
        SetIngredients();
        baseIngredient = new Container(name);
        baseIngredient.types = data;
    }
    protected virtual void SetIngredients() { }
    protected virtual void SetData(string name, Priority priority, Ingredient[] ingredients) {
        data[ingIndex] = new IngredientType(name, (int)priority);
        data[ingIndex].ingredients = ingredients;
        ingIndex++;
    }
}

using UnityEngine;

public class BaseIngredient : MonoBehaviour {
    public Container baseIngredient;
    public Data[] data;
    int ingIndex = 0;


    protected virtual void SetIngredients() { }
    protected virtual void SetData(string name, Priority priority, Ingredient[] ingredient) {
        data[ingIndex] = new Data(name, (int)priority);
        data[ingIndex].type = ingredient;
        ingIndex++;
    }
}

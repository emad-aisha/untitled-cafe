using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink[] drinks;

    int currPriority = 1;

    public void Interact(Collider collider) {
        BaseIngredient ingredient = collider.GetComponent<BaseIngredient>();
        if (!CanInteract(ingredient)) return;

        drinks[(int)ingredient.baseIngredient.GetDrinkType()].Interact(ingredient.baseIngredient, ref currPriority);
    }

    // getters
    public int GetActiveDrinkIndex() {
        for (int i = 0; i < drinks.Length; i++) {
            if (drinks[i].drinkData.IsActive()) { return i; }
        }
        return -1;
    }


    bool CanInteract(BaseIngredient ingredient) {
        bool isActiveDrink = GetActiveDrinkIndex() != -1;
        if (!isActiveDrink) return true;

        bool isSameType = drinks[GetActiveDrinkIndex()].drinkData.GetDrinkType() == ingredient.baseIngredient.GetDrinkType();
        return isSameType;
    }
}

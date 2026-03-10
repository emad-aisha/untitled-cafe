using UnityEngine;

public class CupType : MonoBehaviour, IInteractable {
    public enum CupIngredientType {
        Null,
        Liquid, Syrup,
        CoffeeShot, CoffeeExtras,
        FruitTopping, DessertTopping, DrizzleTopping
    }

    public enum CupMachineType {
        Null,
        Ingredient, Machine
    }

    [Header("Parent Class Variables")]
    [SerializeField] CupIngredientType IngredientType;
    [SerializeField] CupMachineType MachineType;


    virtual public void Interact() {
        Debug.Log("Base Class...");
    }
}

using UnityEngine;

public abstract class CupType : MonoBehaviour, IInteractable {
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

    // drinks
    public enum LiquidType {
        Null,
        Water, Soda, Milk
    }
    public enum SyrupType {
        Null,
        Chocolate, Vanilla, BlueRaspberry
    }

    // coffee
    public enum CoffeeShotType {
        Null,
        Espresso, Decaf
    }
    public enum CoffeeExtraType {
        Null,
        MilkFoam, Chocolate, Sweetener
    }

    // toppings
    public enum FruitType {
        Null,
        Lemon, Lime, Strawberry
    }
    public enum DrizzleType {
        Null,
        Caramel, Chocolate
    }
    public enum DessertType {
        Null,
        WhippedCream, Chocolate
    }


    protected Cup cupObject;

    [Header("Parent Class Variables")]
    [SerializeField] CupIngredientType IngredientType;
    [SerializeField] CupMachineType MachineType;


    public void Interact() {
        GetCupIngredient();
    }

    virtual public Cup GetCupIngredient() {
        Debug.Log("uhhh i think it worked????");

        if ((LiquidType)0 != cupObject.liquid) Debug.Log(cupObject.liquid.ToString());
        if ((SyrupType)0 != cupObject.syrup) Debug.Log(cupObject.syrup.ToString());

        if ((CoffeeShotType)0 != cupObject.coffeeShot) Debug.Log(cupObject.coffeeShot.ToString());
        if ((CoffeeExtraType)0 != cupObject.coffeeExtra) Debug.Log(cupObject.coffeeExtra.ToString());

        if ((FruitType)0 != cupObject.fruit) Debug.Log(cupObject.fruit.ToString());
        if ((DessertType)0 != cupObject.dessert) Debug.Log(cupObject.dessert.ToString());
        if ((DrizzleType)0 != cupObject.drizzle) Debug.Log(cupObject.drizzle.ToString());
        return cupObject;
    }

}

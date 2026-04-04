using UnityEngine;
using static CoffeeInfo;
using static FizzyDrinkInfo;

public enum NameType { Null = -1, FizzyDrink, Coffee, Count };
public class DrinkNameManager : MonoBehaviour {
    static public DrinkNameManager instance;
    public delegate int NameFunction(Drink drink); // function pointer type
    public delegate void CustomerNameFunction(Drink drink); // function pointer type

    void Start() { if (instance == null) instance = this; }

    // TODO: make this set at the start of the scene (to always set to default)
    public int SetDrinkName(Drink drink, NameType nameType) {
        NameFunction SetName = GetFunctionPointer(nameType);
        return SetName(drink);
    }

    public void SetCustomerDrinkName(Drink drink, NameType nameType) {
        CustomerNameFunction SetName = GetCustomerFunctionPointer(nameType);
        SetName(drink);
    }


    public NameFunction GetFunctionPointer(NameType nameType) {
        switch (nameType) {
            case NameType.FizzyDrink: return SetFizzyDrinkInformation;
            case NameType.Coffee: return SetCoffeeInformation;
            case NameType.Null: return SetNoInformation;
            default: Debug.Log("No nametype given"); break;
        }

        return Error;
    }

    public CustomerNameFunction GetCustomerFunctionPointer(NameType nameType) {
        switch (nameType) {
            case NameType.FizzyDrink: return SetCustomerFizzyDrinkInformation;
            case NameType.Coffee: return SetCustomerCoffeeInformation;
            case NameType.Null: return SetNoCustomerInformation;
            default: Debug.Log("No nametype given"); break;
        }

        return CustomerError;
    }


    static public int SetNoInformation(Drink drink) {
        MenuManager.instance.SetInteractionType("NULL");
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");

        return 0;
    }
    static public void SetNoCustomerInformation(Drink drink) {
        MenuManager.instance.SetInteractionType("NULL");
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");
    }

    static public int Error(Drink drink) { Debug.Log("error"); return 0; }
    static public void CustomerError(Drink drink) { Debug.Log("error"); }
}

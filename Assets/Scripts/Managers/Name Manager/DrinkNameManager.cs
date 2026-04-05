using UnityEngine;
using static CoffeeInfo;
using static FizzyDrinkInfo;

public enum NameType { Null = -1, FizzyDrink, Coffee, Count };
public class DrinkNameManager : MonoBehaviour {
    static public DrinkNameManager instance;
    public delegate int NameFunction(Drink drink); // function pointer type
    public delegate void CustomerNameFunction(Drink drink, bool debugMode); // function pointer type
    public delegate void CustomerDebugFunction(Drink drink, bool debugMode); // function pointer type
    // TODO: organize
    // maybe can turn into a namespace instead????

    [SerializeField] bool debugMode;

    void Start() { if (instance == null) instance = this; }

    // TODO: make this set at the start of the scene (to always set to default)
    public int SetDrinkName(Drink drink, NameType nameType) {
        NameFunction SetName = GetFunctionPointer(nameType);
        return SetName(drink);
    }

    public void SetCustomerDrinkName(Drink drink, NameType nameType) {
        CustomerNameFunction SetName = GetCustomerFunctionPointer(nameType);
        SetName(drink, debugMode);
    }

    public void PrintCustomerDrinkName(Drink drink, NameType nameType) {
        CustomerDebugFunction SetName = GetCustomerDebugFunctionPointer(nameType);
        SetName(drink, debugMode);
    }

    // getters
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

    public CustomerDebugFunction GetCustomerDebugFunctionPointer(NameType nameType) {
        switch (nameType) {
            case NameType.FizzyDrink: return SetCustomerDebugFizzyDrinkInformation;
            case NameType.Coffee: return SetCustomerDebugCoffeeInformation;
            case NameType.Null: return SetDebugCustomerInformation;
            default: Debug.Log("No nametype given"); break;
        }

        return DebugCustomerError;
    }

    // null case
    static public int SetNoInformation(Drink drink) {
        MenuManager.instance.SetInteractionType("NULL");
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");

        return 0;
    }
    static public void SetNoCustomerInformation(Drink drink, bool debugMode) {
        MenuManager.instance.SetInteractionType("NULL");
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");
    }
    static public void SetDebugCustomerInformation(Drink drink, bool debugMode) { Debug.Log("No Order"); }

    // no case
    static public int Error(Drink drink) { Debug.Log("error"); return 0; }
    static public void CustomerError(Drink drink, bool debugMode) { Debug.Log("error"); }
    static public void DebugCustomerError(Drink drink, bool debugMode) { Debug.Log("printing error"); }
}

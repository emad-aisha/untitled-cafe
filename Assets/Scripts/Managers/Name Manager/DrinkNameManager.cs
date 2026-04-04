using UnityEngine;
using static CoffeeInfo;
using static FizzyDrinkInfo;

public enum NameType { FizzyDrink, Coffee };
public class DrinkNameManager : MonoBehaviour {
    static public DrinkNameManager instance;
    public delegate int NameFunction(Drink drink); // function pointer type

    void Start() { if (instance == null) instance = this; }

    // TODO: make this set at the start of the scene (to always set to default)
    public int SetDrinkName(Drink drink, NameType nameType) {
        NameFunction SetName = GetFunctionPointer(nameType);
        return SetName(drink);
    }

    public NameFunction GetFunctionPointer(NameType nameType) {
        switch (nameType) {
            case NameType.FizzyDrink: return SetFizzyDrinkInformation;
            case NameType.Coffee: return SetCoffeeInformation;
            default: Debug.Log("No nametype given"); break;
        }

        return Error;
    }


    static public int Error(Drink drink) {
        Debug.Log("error");
        return 0;
    }
}

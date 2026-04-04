using UnityEngine;
using static NamePointers;

public enum NameType { FizzyDrink, Coffee };
public class DrinkNameManager : MonoBehaviour {
    static public DrinkNameManager instance;


    void Start() { if (instance == null) instance = this; }


    public void SetDrinkName(Drink drink, NameType nameType) {
        Name functionPointer = GetFunctionPointer(nameType);
        functionPointer();
    }

    public Name GetFunctionPointer(NameType nameType) {
        switch (nameType) {
            case NameType.FizzyDrink: return FizzyDrinkName;
            case NameType.Coffee: return CoffeeName;
            default: Debug.Log("No nametype given"); break;
        }

        return Error;
    }

}

using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] Drink myFizzyDrink;
    [SerializeField] Drink myCoffee;

    [Header("Debug")]
    [SerializeField] private int currPriority;
    [Header("")]
    public int currMoney = 0;
    public int currPrice;



    public void Interact(Collider interactable) {
        FizzyDrink inputFizzyDrink = interactable.GetComponent<FizzyDrink>();
        Coffee inputCoffee = interactable.GetComponent<Coffee>();

        Drink currDrink = null;

        if (inputFizzyDrink != null && myCoffee.IsEveryStateOff()) {
            inputFizzyDrink.Interact(ref myFizzyDrink, ref currPriority);
            currDrink = myFizzyDrink;
        }
        else if (inputCoffee != null && myFizzyDrink.IsEveryStateOff()) {
            inputCoffee.Interact(ref myCoffee, ref currPriority);
            currDrink = myCoffee;
        }

        // GetDrinkType
        NameType nameType = NameType.Null;
        if (!myFizzyDrink.IsEveryStateOff()) nameType = NameType.FizzyDrink;
        else if (!myCoffee.IsEveryStateOff()) nameType = NameType.Coffee;

        currPrice = nameType switch {
            NameType.FizzyDrink => DrinkNameManager.instance.SetDrinkName(myFizzyDrink, nameType),
            NameType.Coffee => DrinkNameManager.instance.SetDrinkName(myCoffee, nameType),
            _ => currPrice
        };

        MoneyInteract(interactable, nameType);
    }

    void MoneyInteract(Collider interactable, NameType nameType) {
        // TODO: make a class for this?
        if (interactable.CompareTag("Money")) {
            currMoney += currPrice;
            currPrice = 0;
            currPriority = 0;

            switch (nameType) {
                case NameType.Coffee: myCoffee.SetAllOff(); break;
                case NameType.FizzyDrink: myFizzyDrink.SetAllOff(); break;
                default: Debug.Log("Set Nothing Off"); break;
            }

            DrinkNameManager.instance.SetDrinkName(null, NameType.Null);
            MenuManager.instance.SetPlayerMoney(currMoney.ToString());
        }
    }

}

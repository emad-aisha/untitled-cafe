using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;

    [Header("Basic Drink")]
    [SerializeField] TMP_Text baseType;
    [SerializeField] TMP_Text subType;

    [Header("Finals")]
    [SerializeField] TMP_Text drinkName;
    [SerializeField] TMP_Text cost;
    [SerializeField] TMP_Text totalMoney;

    [Header("Customer")]
    [SerializeField] TMP_Text customerOrder;
    [SerializeField] TMP_Text customerPrice;
    // TODO: make this easier to read + consistent

    void Start() { if (instance == null) instance = this; }

    public void SetInteractionTypes(string typeName, string _lastInteracted) {
        SetBaseType(typeName);
        SetSubType(_lastInteracted);
    }
    public void SetBaseType(string typeName) { baseType.text = typeName; }
    public void SetSubType(string _subType) { subType.text = _subType; }

    public void SetDrinkInfo(string finalDrinkName, string finalCost) {
        SetDrinkName(finalDrinkName);
        SetCost(finalCost);
    }
    public void SetDrinkName(string finalDrinkName) { drinkName.text = finalDrinkName; }
    public void SetCost(string finalCost) { cost.text = finalCost; }

    public void SetPlayerMoney(string money) { totalMoney.text = money; }
    public int GetPlayerMoney() { return int.Parse(totalMoney.text); }


    public void SetCustomerInfo(string order, string price) {
        SetCustomerOrder(order);
        SetCustomerPrice(price);
    }
    public void SetCustomerOrder(string order) { customerOrder.text = order; }
    public void SetCustomerPrice(string price) { customerPrice.text = price; }
}

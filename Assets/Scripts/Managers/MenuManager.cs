using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;

    [Header("Basic Drink")]
    [SerializeField] TMP_Text baseInteraction;
    [SerializeField] TMP_Text baseType;

    [Header("Finals")]
    [SerializeField] TMP_Text finalDrink;
    [SerializeField] TMP_Text cost;
    [SerializeField] TMP_Text totalMoney;

    [Header("Customer")]
    [SerializeField] TMP_Text customerOrder;


    void Start() { if (instance == null) instance = this; }


    public void SetInteractionType(string typeName) { baseType.text = typeName; }

    public void SetDrinkInformation(string BaseType, string finalDrinkName, int cost) {
        SetBaseInteraction(BaseType);
        SetFinalDrink(finalDrinkName);
        SetCost(cost.ToString());
    }
    public void SetBaseInteraction(string interactionName) { baseInteraction.text = interactionName; }
    public void SetFinalDrink(string finalDrinkName) { finalDrink.text = finalDrinkName; }
    public void SetCost(string finalCost) { cost.text = finalCost; }

    public void SetPlayerMoney(string money) { totalMoney.text = money; }


    public void SetCustomerOrder(string order) { customerOrder.text = order; }
}

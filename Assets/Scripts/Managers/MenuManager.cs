using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;

    [Header("Basic Drink")]
    [SerializeField] TMP_Text lastInteracted;
    [SerializeField] TMP_Text baseType;

    [Header("Finals")]
    [SerializeField] TMP_Text finalDrink;
    [SerializeField] TMP_Text cost;

    void Start() { if (instance == null) instance = this; }


    public void SetInteractionType(string typeName) { baseType.text = typeName; }

    public void SetLastInteracted(string _lastInteracted) { lastInteracted.text = _lastInteracted; }
    public void SetFinalDrink(string finalDrinkName) { finalDrink.text = finalDrinkName; }
    public void SetCost(string finalCost) { cost.text = finalCost; }
}

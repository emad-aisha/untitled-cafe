using UnityEngine;

public class Coffee : MonoBehaviour {
    [HideInInspector] public enum Priorities { first, second, third };
    [SerializeField] Espresso espresso;
    [SerializeField] Liquid liquid;
    [SerializeField] Extras extras;

    void Start() {
        espresso = gameObject.GetComponent<Espresso>();
        liquid = gameObject.GetComponent<Liquid>();
        extras = gameObject.GetComponent<Extras>();
    }

    public void Interact(ref Coffee input, ref int priority) {
        if (espresso && IsMatching(espresso.priority, priority)) { espresso.Set(ref input.espresso, ref priority); }
        else if (liquid && IsMatching(liquid.priority, priority)) { liquid.Set(ref input.liquid, ref priority); }
        else if (extras && input.liquid.hasWater == false && IsMatching(extras.priority, priority)) { extras.Set(ref input.extras, ref priority); }
        // can only add the extras if there's no water

        DrinkManager.instance.SetFinalCoffeeDrink(input);
    }

    bool IsMatching(Priorities priority, int checkedPriority) {
        return priority == (Priorities)checkedPriority;
    }



    // getters
    public Espresso GetEspresso() { return espresso; }
    public Liquid GetLiquid() { return liquid; }
    public Extras GetExtras() { return extras; }

    // setters
    public void SetEspresso(Espresso newEspresso) { espresso = newEspresso; }
    public void SetLiquid(Liquid newLiquid) { liquid = newLiquid; }
    public void SetExtras(Extras newExtras) { extras = newExtras; }
}

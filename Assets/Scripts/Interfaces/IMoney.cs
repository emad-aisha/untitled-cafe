

public interface IMoney {
    public void Interact();

    public void ClearInfo(int currMoney) {
        MenuManager.instance.SetFinalDrink("nothing");
        MenuManager.instance.SetCost("0");

        MenuManager.instance.SetPlayerMoney(currMoney.ToString());
    }

    public void ResetDrinkInfo(ref Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) {
            drinks[i].ResetInfo();
        }
    }
}

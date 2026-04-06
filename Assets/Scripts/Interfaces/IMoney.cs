

public interface IMoney {
    public void ClearInfo(int currMoney) {
        SetDrinkInfo("nothing", "0");
        MenuManager.instance.SetPlayerMoney(currMoney.ToString());
    }

    public void ResetDrinkInfo(ref Drink[] drinks) {
        for (int i = 0; i < drinks.Length; i++) {
            drinks[i].ResetInfo();
        }
    }

    void SetDrinkInfo(string finalDrink, string cost) {
        MenuManager.instance.SetFinalDrink(finalDrink);
        MenuManager.instance.SetCost(cost);
    }
}

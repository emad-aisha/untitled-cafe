

public interface IMoney {
    public void ResetInfo(int currMoney) {
        SetDrinkInfo("nothing", "0");
        MenuManager.instance.SetPlayerMoney(currMoney.ToString());
    }

    void SetDrinkInfo(string finalDrink, string cost) {
        MenuManager.instance.SetFinalDrink(finalDrink);
        MenuManager.instance.SetCost(cost);
    }

}

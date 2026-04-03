using UnityEngine;

public enum Priorities { First, Second, Third };
public abstract class Drinks : MonoBehaviour {
    public int price;

    public bool CheckPriorities(Priorities check, Priorities input) { return check == input; }
    public bool CheckPriorities(int check, int input) { return check == input; }

    abstract public bool IsEveryStateOff();
    abstract public void SetAllOff();
}

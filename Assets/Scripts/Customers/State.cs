using UnityEngine;


public abstract class State : MonoBehaviour {
    [SerializeField] public CustomerInformation info;

    public abstract void UpdateState();

    public void SetCustomerInfo(CustomerInformation _customerInfo) { info = _customerInfo; }
}

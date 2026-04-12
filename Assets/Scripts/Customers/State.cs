using UnityEngine;


public class State : MonoBehaviour {
    [SerializeField] public CustomerInformation info;

    // TODO: update function
    public virtual void UpdateState() { }


    public void SetCustomerInfo(CustomerInformation _customerInfo) { info = _customerInfo; }
}

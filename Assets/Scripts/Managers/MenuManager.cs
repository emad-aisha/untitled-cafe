using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager instance;

    [SerializeField] TMP_Text baseInteraction;
    [SerializeField] TMP_Text baseType;

    void Start() {
        if (instance == null) instance = this;
    }

    public void SetBaseInteraction(string interactionName) {
        baseInteraction.text = interactionName;
    }

    public void SetInteractionType(string typeName) {
        baseType.text = typeName;
    }

}

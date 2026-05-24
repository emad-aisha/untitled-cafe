using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Drink), true)]
public class DrinkEditor : Editor {
    enum Case { All = -1, None = -2 }
    bool showDictionary;

    void OnEnable() {
        var drink = (Drink)target;

        if (drink.internalData == null) drink.InitializeInternalData();
        if (drink.ingredients == null) drink.InitializeDictionary();
        showDictionary = false;
    }

    public override void OnInspectorGUI() {
        EditorGUI.BeginChangeCheck();
        serializedObject.Update();
        var drink = (Drink)target;

        ShowIngredientData();
        ShowButton("Hide Setters?", ref drink.hideInternalData);

        if (drink.hideInternalData) ShowInteractData();

        ShowButton("Show Dictionary Data?", ref showDictionary);
        if (Application.isPlaying) showDictionary = true;

        if (drink.ingredientData == null) {
            serializedObject.ApplyModifiedProperties();
            if (drink.ingredientData != null) ResetData(ref drink);
            return;
        }

        if (EditorGUI.EndChangeCheck()) {
            ResetData(ref drink);
            Repaint();
        }
        Undo.RecordObject(drink, "internalData");

        if (!drink.hideInternalData) SetValue<FizzyDrink.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientType.FizzyDrink);
        if (!drink.hideInternalData) SetValue<Coffee.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientType.Coffee);

        if (!showDictionary) {
            if (!drink.hideInternalData) DrawInternalData(ref drink);
        }
        else {
            DrawDictionary(ref drink);
        }

        serializedObject.ApplyModifiedProperties();
    }


    void ShowIngredientData() {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ingredientData"));
        EditorGUILayout.Space();
    }

    void ShowInteractData() {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactData"));
        EditorGUILayout.Space();
    }

    void ResetData(ref Drink drink) {
        drink.InitializeInternalData();
        drink.InitializeDictionary();
        serializedObject.ApplyModifiedProperties();
    }

    void ShowButton(string label, ref bool value) {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        GUILayout.Space(50);
        value = EditorGUILayout.Toggle(value);
        GUILayout.EndHorizontal();
    }

    void DrawInternalData(ref Drink drink) {
        EditorGUILayout.LabelField("Internal Data", EditorStyles.boldLabel);
        switch (drink.type) {
            case (int)Case.All: Show.All(ref drink, true); break;
            case (int)Case.None: Show.All(ref drink, false); break;
            default: Show.ShowValues(ref drink, drink.type); break;
        }
    }

    void DrawDictionary(ref Drink drink) {
        EditorGUILayout.LabelField("Ingredients Dictionary", EditorStyles.boldLabel);
        switch (drink.type) {
            case (int)Case.All: Show.ShowDictionaryAll(drink, true); break;
            case (int)Case.None: Show.ShowDictionaryAll(drink, false); break;
            default: Show.ShowDictionaryValues(drink, drink.type); break;
        }
        Repaint();
    }

    void SetValue<NewIngredientType>(ref int value, IngredientType drinkType, IngredientType ingredientType)
    where NewIngredientType : System.Enum {
        if (drinkType == ingredientType) value = (int)(object)(NewIngredientType)EditorGUILayout.EnumPopup((NewIngredientType)(object)value);
    }


    [MenuItem("CONTEXT/Drink/Refresh Data")]
    public static void RefreshSOS() {
        AssetDatabase.Refresh();
    }

}

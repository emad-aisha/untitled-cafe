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
        serializedObject.Update();
        var drink = (Drink)target;

        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ingredientData"));
        EditorGUILayout.Space();

        if (Application.isPlaying) showDictionary = true;

        if (drink.ingredientData == null) {
            serializedObject.ApplyModifiedProperties();

            // if set to real object , init
            if (drink.ingredientData != null) {
                drink.InitializeInternalData();
                drink.InitializeDictionary();
                serializedObject.ApplyModifiedProperties();
            }
            return;
        }

        if (EditorGUI.EndChangeCheck()) {
            drink.InitializeInternalData();
            drink.InitializeDictionary();
            serializedObject.ApplyModifiedProperties();
            Repaint();
        }
        Undo.RecordObject(drink, "internalData");

        SetValue<FizzyDrink.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientType.FizzyDrink);
        SetValue<Coffee.Ingredient>(ref drink.type, drink.ingredientData.Type, IngredientType.Coffee);

        if (!showDictionary) {
            DrawInternalData(ref drink);
        }
        else {
            DrawDictionary(ref drink);
        }

        serializedObject.ApplyModifiedProperties();
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


    void test(SerializedProperty proprty) {

    }

    void SetValue<NewIngredientType>(ref int value, IngredientType drinkType, IngredientType ingredientType)
    where NewIngredientType : System.Enum {
        if (drinkType == ingredientType) value = (int)(object)(NewIngredientType)EditorGUILayout.EnumPopup((NewIngredientType)(object)value);
    }

}

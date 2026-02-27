using UnityEngine;
using System.Collections.Generic;
using System;


public class Cup : Interact{



    public List<bool> States;
    public enum CupStates {
        ice = 0,
        water,
        coffee,
        milk,
        chocolate
    }

    void Start() {
        SetStates();

    }

    void SetStates(bool state = false) {
        int numOfStates = Enum.GetNames(typeof(CupStates)).Length;

        for (int i = 0; i < numOfStates; i++) {
            States.Add(state);
        }
    }

    void GetDrink(CupStates state) {
        States[(int)state] = true;



    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();

        for (int state_idx=0; state_idx<nextStates.Length; state_idx++) {
            if ( Input.GetKeyDown(KeyCode.Alpha1 + state_idx)) { 
                changeState(nextStates, state_idx);
			}
		}
    }

    private void changeState(State[] nextStates, int nextState)
    {
        currentState = nextStates[nextState];
        textComponent.text = currentState.GetStateStory();
    }
}

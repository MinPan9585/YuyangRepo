using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerStateMachine
{
    public RollerState currentState { get; private set; }
    // Start is called before the first frame update

    public void Initialize(RollerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
        Debug.Log(_startState+ "Entered");
    }
    public void ChangeState(RollerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
        Debug.Log(_newState+"Entered");
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stoveIdleState : StoveState
{
    public stoveIdleState(StoveStateMachine stateMachine, Stove stove) : base(stateMachine, stove)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void Update()
    {
        base.Update();
        if (stove.canActive)
            stateMachine.ChangeState(stove.stoveActiveState);
    }

   
}

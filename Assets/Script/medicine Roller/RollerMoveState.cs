using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RollerMoveState : RollerState
{
    public RollerMoveState(RollerStateMachine stateMachine, Roller roller) : base(stateMachine, roller)
    {

    }
    private Vector3 offset;

    public override void Enter()
    {
        base.Enter();
        roller.stickRb.isKinematic = true;
        roller.canWork = true;
        roller.StartCoroutine("ActiveStick");


    }

    public override void Exit()
    {
        base.Exit();
        roller.isActivated = false;
        roller.canWork = false;
        
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        moveStick();
        if (roller.isActivated)
            SetRotation(roller.stick,0, 0, 0);
    }


    public override void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0)&&roller.isActivated)
        {
            roller.stateMachine.ChangeState(roller.idleState);
        }
    }
    private void moveStick()
    {
        if (roller.isActivated)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            roller.stick.transform.position = mousePosition;
            
        }
    }
    
}

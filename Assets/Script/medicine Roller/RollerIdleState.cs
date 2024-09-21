using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RollerIdleState : RollerState
{
    public RollerIdleState(RollerStateMachine stateMachine, Roller roller) : base(stateMachine, roller)
    {
    }
    //private bool isDragging = false;
    private Vector3 offset;

    public override void Enter()
    {
        base.Enter();
        roller.stickRb.isKinematic = false;
        roller.stick.transform.rotation = Quaternion.Euler(0, 0, 2);
        roller.StartCoroutine("ResetStick");

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
        ActiveMoveState();

    }

    private void ActiveMoveState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && (hit.collider.gameObject == roller.gameObject|| hit.collider.gameObject == roller.stick.gameObject))
            {
                roller.stateMachine.ChangeState(roller.moveState);
            }
        }
    }
    
}

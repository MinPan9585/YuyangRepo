using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stoveActiveState : StoveState
{
    public stoveActiveState(StoveStateMachine stateMachine, Stove stove) : base(stateMachine, stove)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        if(stove.isFire)
            stove.InstantiateFire();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        StartFire();
        if (!stove.canActive)
            stateMachine.ChangeState(stove.stoveIdleState);
    }
    private void StartFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("FirePlace"))
            {
                stove.InstantiateFire();
            }
        }
    }
    
}

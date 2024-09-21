using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveState
{
    protected Rigidbody2D rb;
    protected StoveStateMachine stateMachine;
    protected Stove stove;
    protected float stateTimer;
    protected bool triggerCalled;
    public StoveState(StoveStateMachine stateMachine, Stove stove)
    {
        this.stateMachine = stateMachine;
        this.stove = stove;
    }

    public virtual void Enter()
    {
        rb = stove.rb;

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {

    }
    public virtual void FixedUpdate()
    {

    }
    
    public void SetRotation(Transform _obj, float x, float y, float z)
    {
        _obj.transform.rotation = Quaternion.Euler(x, y, z);
    }
    public void SetVelocity(Transform _obj, float x, float y)
    {

    }

}

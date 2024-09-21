using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Playables;

public class RollerState 
{
    protected Rigidbody2D rb;
    protected RollerStateMachine stateMachine;
    protected Roller roller;
    protected float stateTimer;
    protected bool triggerCalled;
    public RollerState(RollerStateMachine stateMachine, Roller roller)
    {
        this.stateMachine = stateMachine;
        this.roller = roller;
    }

    public virtual void Enter()
    {
        rb = roller.rb;

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
    public void SetVelocity(Transform _obj, float x,float y)
    {

    }
}

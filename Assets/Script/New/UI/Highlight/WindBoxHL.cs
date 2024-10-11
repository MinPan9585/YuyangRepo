using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBoxHL : Highlight
{
    public WindBox windBox;
    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if(gameObject.GetComponent<Rigidbody2D>().velocity.x !=0||!windBox.canActiveWindBox)
            isBusy = true;
        else
            isBusy = false;
    }
}

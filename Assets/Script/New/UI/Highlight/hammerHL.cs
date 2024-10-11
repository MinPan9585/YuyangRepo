using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerHL : Highlight
{
    public Animator animator;
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
        if(animator.GetBool("isSmashing"))
            isBusy = true;
        else
            isBusy = false;
    }
}

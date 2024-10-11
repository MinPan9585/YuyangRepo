using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class FirePlaceHL : Highlight
{
    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
        Debug.Log("2");
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
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("1");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("FirePlace"))
            {
                isBusy = true;
            }
        }
    }
}

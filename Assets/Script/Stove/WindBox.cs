using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBox : MonoBehaviour
{
    private Vector2 windBoxPos;
    private Vector2 currentWindBoxPos;
    private Vector2 initialPos;
    private Vector2 offset;
    private float offsetValue;

    public Rigidbody2D rb;
    public bool canActiveWindBox;
    public bool canMove;
    public float moveHandleDistance;
    private void Awake()
    {
        canActiveWindBox = false;
        rb = GetComponent<Rigidbody2D>();
        windBoxPos = transform.position;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        DragHandle();
        MoveHandle();
    }
    #region HandleMovements
    private void DragHandle()
    {
        if (canActiveWindBox)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("WindBox"))
                    {
                        initialPos = hit.point;
                        canMove = true;
                    }
                }
            }
            if (Input.GetMouseButton(0)&&canMove)
            {
                Vector2 currrentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = currrentMousePos - initialPos;
                offsetValue = Vector2.Distance(currrentMousePos, initialPos);
            }
            if (Input.GetMouseButtonUp(0))
            {
                offsetValue = 0;
                offset = Vector2.zero;
                canMove = false;
            }
            
        }
    }
    private void MoveHandle()
    {
        Vector2 boxOffset = currentWindBoxPos - windBoxPos;
        currentWindBoxPos = transform.position;
        if (canActiveWindBox && Vector2.Distance(windBoxPos, currentWindBoxPos) <= moveHandleDistance)
        {
            rb.velocity = new Vector2(offset.normalized.x, 0);
        }
        else if(boxOffset.x<0&&offset.x>0)
        {
            rb.velocity = new Vector2(offset.normalized.x, 0);
        }
        else if(boxOffset.x > 0 && offset.x < 0)
        {
            rb.velocity = new Vector2(offset.normalized.x, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    #endregion 
}

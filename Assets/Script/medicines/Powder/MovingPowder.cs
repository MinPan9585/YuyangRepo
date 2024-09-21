using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPowder : MonoBehaviour
{
    [HideInInspector]public bool canMove = false;
    public Stat totalValue;
    public Stat charValue;
    private Rigidbody2D rb;

    public int currentTotalValue;
    public int currentCharValue;
    private void Awake()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCharValue = charValue.GetValue();
        currentTotalValue = totalValue.GetValue(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == transform.gameObject)
            {
                canMove = !canMove;
            }
        }
    }
    private void FixedUpdate()
    {
        MovePowder();
    }
    private void MovePowder()
    {
        if (canMove)
        {
            rb.isKinematic = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;

        }
        else
        {
            rb.isKinematic= false;
        }
    }
}

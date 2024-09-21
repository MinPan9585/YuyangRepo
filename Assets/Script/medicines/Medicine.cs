using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    #region Components
    protected Rigidbody2D rb;
    protected Powder powder;
    public Roller roller;
    public GameObject ins_Powder;
    public GameObject instantiatedPowder;
    public Transform PowderPos;
    [HideInInspector] public Vector3 mousePos;
    #endregion
    #region moveBool
    [HideInInspector]public bool isMoving;
    [HideInInspector]public bool isMashed;
    [HideInInspector]public static bool isSpawned;
    #endregion
    public virtual void Awake()
    {
        isMoving = false;
        isMashed = false;
        rb = GetComponent<Rigidbody2D>();
        GameObject _powderSpawnPoint = GameObject.Find("Roller");
        PowderPos = _powderSpawnPoint.transform.Find("PowderPos");
    }
    
    public virtual void Start()
    {
        
    }

    
    public virtual void Update()
    {
        MoveDetection();
        DestoryPowder();
        DestoryMed();
        
    }


    public virtual void FixedUpdate()
    {
        MoveMed();

    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        roller = collision.GetComponent<Roller>();
        if (collision.CompareTag("Roller")&&!isSpawned&&instantiatedPowder == null)
        {
            instantiatedPowder = Instantiate(ins_Powder, PowderPos.position,PowderPos.rotation);
            isSpawned = true;
        }
        else
        {
            instantiatedPowder = GameObject.Find("P_Mahuang(Clone)");
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    private void DestoryPowder()
    {
        if (instantiatedPowder != null)
        {
            if (powder.totalValue <= 0&&!isMashed)
            {
                Destroy(instantiatedPowder);
                isSpawned = false;
            }

        }
    }
    private void MoveDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == transform.gameObject&&!isMoving)
            {
                isMoving = true;
            }
            else if(isMoving)
            {
                isMoving = false;
                rb.isKinematic = false;
            }
        }
    }
    private void MoveMed()
    {
        if (isMoving)
        {
            rb.isKinematic = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;

        }
    }

    private void DestoryMed()
    {
        if (transform.localScale.x <= 0.05)
            Destroy(gameObject);
    }
    
}

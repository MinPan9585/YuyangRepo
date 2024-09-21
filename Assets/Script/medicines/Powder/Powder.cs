using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Powder : MonoBehaviour
{
    public int totalValue;
    public int CharValue;
    public Roller roller;
    public GameObject movingPowder;
    public GameObject InstantiatedPowder;
    private MovingPowder M_powder;
    //private bool canMove;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        ActiveMovePowder();
    }

    private void ActiveMovePowder()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (roller.Meds.All(item => item == null))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && (hit.collider.gameObject == gameObject))
                {
                    Vector3 _spawnSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    InstantiatedPowder = Instantiate(movingPowder,_spawnSpot,Quaternion.Euler(0,0,0));
                    M_powder = InstantiatedPowder.GetComponent<MovingPowder>();
                    M_powder.totalValue.AddModifier(totalValue);

                    Medicine.isSpawned = false;
                    Destroy(gameObject);
                }

            }
        }
    }

    /*private void MovePowder()
    {
        if (canMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;

        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Roller"))
        {
            roller = collision.GetComponent<Roller>();
        }
    }
}

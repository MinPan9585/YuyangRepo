using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float tempReduce;
    public float healReduce;
    public float poisReduce;

    public Animator animator;

    private StateManager stateManager;
    private MedMaking medMaking;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        medMaking = FindAnyObjectByType<MedMaking>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.state == 2)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0)&&hit.collider.CompareTag("Bucket"))
                {
                    animator.SetBool("canPour", true);
                    medMaking.currentTemp -= tempReduce;
                    medMaking.reduceheal += healReduce;
                    medMaking.reducePois += poisReduce;
                    //medMaking.currentTime = 0;
                }
            }
        }
    }

    public void SetAnimBool()
    {
        animator.SetBool("canPour", false);
    }
}

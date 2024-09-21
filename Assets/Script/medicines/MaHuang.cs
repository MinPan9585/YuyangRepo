using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaHuang : Medicine
{
    
    private MaHuangStat stat;
    private bool flag;
    public override void Awake()
    {
        base.Awake();
        stat = transform.GetComponent<MaHuangStat>();
        flag = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Roller")&&!flag)
        {
            if (isSpawned)
            {
                powder = FindAnyObjectByType<Powder>();
            }
            else
            {
                powder = instantiatedPowder.GetComponent<Powder>();

            }
            powder.totalValue += stat.currentPowderValue;
            flag = true;

        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if (collision.CompareTag("Roller")&&flag&&!isMashed)
        {
            powder.totalValue -= stat.currentPowderValue;
            flag = false;
        }
        
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}

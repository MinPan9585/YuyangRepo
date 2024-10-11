using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedMaking : MonoBehaviour
{
    [Header("Timer")]
    public float publicTimer;
    public float roundTime;

    [Header("MaxValue")]
    public float maxHeal;
    public float maxPois;
    public float maxTemp;

    [Header("CurrentValue")]
    public float currentTime;
    public float currentHeal;
    public float currentPois;
    public float currentTemp;
    [Header("AddOn")]
    public float overcookRate;
    public float reduceTemp;
    public float reducePois;
    public float reduceheal;

    [HideInInspector]public bool start;

    [SerializeField]private bool isBoiling;
    private bool resetTime;

    private float baseHeal;
    private float basePois;
    private float baseTemp;

    private float boilHeal;
    private float boilPois;
    private float _heal;
    private float _pois;

    private GameObject fire;

    private StateManager stateManager;
    [SerializeField]private BaseMed medInfo;

    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        publicTimer = roundTime;
        fire = GameObject.Find("Fire");
    }

    void Update()
    {
        Debug.Log("boilHeal"+boilHeal+"  "+"boilPois" + boilPois+ "  " + "_pois" + _pois+ "  " + "_heal" + _heal);
        StateManaging();
        SignBaseValue();
        CalculateCurrentValue();
        CurrentValueWhenBoiling();
        CheckIsBoiling();
    }

    private void StateManaging()
    {
        if (stateManager.state == 2 && start)
            publicTimer -= Time.deltaTime;
        if (publicTimer <= 0)
            stateManager.state = 3;
    }

    private void SignBaseValue()
    {
        if (GameObject.Find("MixedMed(Clone)") != null)
        {
            medInfo = GameObject.Find("MixedMed(Clone)").GetComponent<BaseMed>();
            baseHeal = medInfo.cure;
            basePois = medInfo.pois;
        }
    }

    private void CalculateCurrentValue()
    {
        if (isBoiling)
        {
            boilHeal = currentHeal;
            boilPois = currentPois;
        }
        if (stateManager.state == 2&&start)
        {
            currentTime += Time.deltaTime;

            baseTemp = (fire.transform.localScale.x - 1) * 10;
            if (!isBoiling)
            {
                if (!resetTime)
                {
                    currentTime = 0;
                    reduceheal = 0;
                    //reducePois = 0;
                    resetTime = true;
                }
                if (currentHeal <= maxHeal)
                    currentHeal = (100 + baseHeal) * (1 - Mathf.Exp(-0.05f * currentTime)) - reduceheal + boilHeal;
                else
                    currentHeal = maxHeal;
                if(currentPois <= maxPois)
                    currentPois = (50 + basePois) * (1 - Mathf.Exp(-0.05f * currentTime)) - reducePois + boilPois;
                else
                    currentPois = maxPois;
                if (currentHeal >= maxHeal)
                    reducePois -= overcookRate * Time.deltaTime;
            }
            if (currentTemp <= maxTemp)
                currentTemp += (1+baseTemp) * Time.deltaTime;
        }
        if(publicTimer<=0)
            start = false;
        if (currentHeal <= 0)
        {
            currentHeal = 0;
            reduceheal = 0;
        }
        if (currentPois <= 0)
        {
            currentPois = 0;
            reducePois = 0;
        }
        if (currentTemp <= 0)
        {
            currentTemp = 0;
            reduceTemp = 0;
        }
    }

    private void CurrentValueWhenBoiling()
    {
        if (!isBoiling)
        {
            _heal = currentHeal;
            _pois = currentPois;
        }
        if (stateManager.state == 2 && start && isBoiling)
        {
            if (resetTime)
            {
                currentTime = 0;
                reduceheal = 0;
                reducePois = 0;
                resetTime = false;
            }
            if (currentHeal <= maxHeal)
                currentHeal = (160 + baseHeal) * (1 - Mathf.Exp(-0.05f * currentTime)) - reduceheal + _heal;
            else
                currentHeal = maxHeal;
            if(currentPois<=maxPois)
                currentPois = (80 + basePois) * (1 - Mathf.Exp(-0.05f * currentTime)) - reducePois + _pois;
            else
                currentPois = maxPois;
            if (currentHeal >= maxHeal)
                reducePois -= overcookRate * Time.deltaTime;
        }
    }
    private void CheckIsBoiling()
    {
        if (currentTemp >= maxTemp)
            isBoiling = true;
        else
            isBoiling = false;
    }
}

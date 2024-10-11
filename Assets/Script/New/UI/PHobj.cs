using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHobj : MonoBehaviour
{
    private StateManager stateManager;
    private bool isOpen = false;
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.state == 1&&!isOpen)
        {
            LeanTween.moveY(transform.gameObject, 0, 1).setEaseInOutCubic();
            isOpen = true;
        }

    }
}

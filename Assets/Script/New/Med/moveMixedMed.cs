using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class moveMixedMed : MonoBehaviour
{
    public Animator animator;
    public MoveStove moveStove;
    public EndStateButton endStateButton;
    
    private StateManager stateManager;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        endStateButton = GameObject.Find("EndStateOne").GetComponent<EndStateButton>();
        endStateButton.canDisplay = true;
        moveStove = FindAnyObjectByType<MoveStove>();
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.state == 2&&!canMove)
        {
            animator.SetBool("canMove", true);
            canMove = true;
        }
    }
    private void SetAnimBool()
    {
        animator.SetBool("canMove",false);
        moveStove.canMove = true;
    }
}

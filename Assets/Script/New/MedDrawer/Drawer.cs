using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drawer : MonoBehaviour
{
    public StateManager stateManager;
    [SerializeField]private Animator animator;
    [SerializeField] GameObject buttonList;
    [SerializeField]private List<GameObject> buttons = new List<GameObject>();
    private int animNum = 0;
    public bool isBusy = false;
    // Start is called before the first frame update
    void Start()
    {
       stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
       foreach(Transform _buttons in buttonList.transform)
       {
           buttons.Add(_buttons.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.state == 1)
        {
            AddMedicine();

        }
    }

    private void AddMedicine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && buttons.Contains(hit.collider.gameObject))
            {
                GameObject _button = hit.collider.gameObject;
                _button.GetComponent<SpriteRenderer>().enabled = false;
                animNum = buttons.IndexOf(_button)+1;
                animator.SetInteger("animNum",animNum);
            }
        }
    }

    public void SetAnimIdle()
    {
        Debug.Log("animtriggered");
        animator.SetInteger("animNum", 0);
    }

    public void SetAnimBool()
    {
        isBusy = !isBusy;
    }
}

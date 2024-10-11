using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Highlight : MonoBehaviour
{
    public int targetState;

    [SerializeField] private GameObject highlight;
    [SerializeField]private StateManager stateManager;
    private GameObject instantiatedHL;
    private bool canActive = true;
    protected bool isBusy = false;
    // Start is called before the first frame update
    public virtual void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Destroy(instantiatedHL);
                canActive = false;
            }
        }
    }
    public virtual  void OnMouseEnter()
    {
        if (stateManager.state == targetState && canActive && !isBusy)
        {
            instantiatedHL = Instantiate(highlight,transform);
            instantiatedHL.transform.position = transform.position;
        }
        else
            Destroy(instantiatedHL);
    }

    public virtual void OnMouseExit()
    {
        if (stateManager.state == targetState)
            Destroy(instantiatedHL);
        canActive = true;
    }
}

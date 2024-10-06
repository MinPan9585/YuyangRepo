using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    public Fire fire;
    public WindBox windBox;

    private StateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stateManager.state == 2)
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.CompareTag("FirePlace"))
                {
                    fire.GetComponent<SpriteRenderer>().enabled = true;
                    windBox.canActiveWindBox = true;
                }
            }
        }
    }
}

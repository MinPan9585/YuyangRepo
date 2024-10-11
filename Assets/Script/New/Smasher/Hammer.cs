using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Animator animator;

    private bool isSmashing;
    private bool isBusy;
    private StateManager stateManager;
    private GameObject mixedMed;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isSmashing", isSmashing);
        mixedMed = GameObject.Find("MixedMed(Clone)");
        if (stateManager.state == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if(hits.Length > 0)
                {
                    foreach(RaycastHit2D hit in hits)
                    {
                        if (hit.collider != null&& hit.collider.CompareTag("Hammer"))
                        {
                            if (!isBusy&&mixedMed!=null)
                            {
                                mixedMed.GetComponent<BaseMed>().cure += 2;
                                mixedMed.GetComponent<BaseMed>().pois += 2;
                            }
                            isSmashing = true;
                            isBusy = true;
                    
                        }
                        else
                            Debug.Log("");
                    }
                }
            }
        }
    }
    public void SetAnimBool()
    {
        isBusy = false;
        isSmashing = false;
    }
}

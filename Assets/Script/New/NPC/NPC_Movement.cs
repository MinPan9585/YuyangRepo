using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    public NPCDialog Dialog;
    public GameObject Text;
    private StateManager stateManager;
    private GameObject mask;
    private bool isOpen = false;
    private bool canTalk = false;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        mask = GameObject.Find("Mask");
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.state == 0 && !isOpen)
        {
            LeanTween.moveX(transform.gameObject, -2.2f, 1).setEaseInOutCubic()
                     .setOnComplete(() =>
                     {
                         mask.GetComponent<SpriteRenderer>().enabled = true;
                         canTalk = true;
                     });
            isOpen = true;
        }

        if (stateManager.state != 0 && isOpen)
        {
            LeanTween.moveX(transform.gameObject, -11f, 1).setEaseInOutCubic();
            mask.GetComponent<SpriteRenderer>().enabled = false;
            canTalk = false;
            isOpen = false;
        }
        Dialog.gameObject.SetActive(canTalk);
        Text.gameObject.SetActive(canTalk);
    }
    
}

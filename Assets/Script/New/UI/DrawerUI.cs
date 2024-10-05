using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerUI : MonoBehaviour
{
    [SerializeField]private StateManager stateManager;
    [SerializeField]private Drawer drawer;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        drawer = FindAnyObjectByType<Drawer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HighlightDrawer()
    {
        if(stateManager.state == 1)
        {
            
        }
    }
    private void OnMouseEnter()
    {
        if(stateManager.state == 1&&!drawer.isBusy)
            spriteRenderer.enabled = true;
        else
            spriteRenderer.enabled = false;
    }

    private void OnMouseExit()
    {
        if (stateManager.state == 1)
            spriteRenderer.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndStateButton : MonoBehaviour
{
    public int targetState;
    public int currentState;
    public bool canDisplay;

    private StateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayButton();
    }

    public void enterState()
    {
        stateManager.state = targetState; 
    }

    private void DisplayButton()
    {
        if(stateManager.state != currentState||!canDisplay)
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().enabled = false;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
        else if(canDisplay&& stateManager.state == currentState)
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        }
    }
}

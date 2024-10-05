using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public Text dialogueText;
    public Image image;
    public string[] dialogues; 
    public float typingSpeed = 0.05f;

    private int dialogueIndex = 0;
    private bool isTyping = false;
    private bool skipDialogue = false;
    private StateManager stateManager;

    private void OnEnable()
    {
        dialogueIndex = 0;
        StartCoroutine(DisplayDialogue());
    }
    void Start()
    {
        stateManager = GameObject.FindObjectOfType<StateManager>();
    }

    void Update()
    {
        if(stateManager.state == 0)
        {
            if (Input.anyKeyDown && isTyping)
            {
                skipDialogue = true;
            }
            else if (Input.anyKeyDown && !isTyping)
            {
                if (dialogueIndex < dialogues.Length - 1)
                {
                    dialogueIndex++;
                    StartCoroutine(DisplayDialogue());
                }
                else
                {
                    stateManager.state = 1;
                }
            }
        }
    }

    IEnumerator DisplayDialogue()
    {
        isTyping = true;
        dialogueText.text = ""; 
        string currentDialogue = dialogues[dialogueIndex];

        for (int i = 0; i < currentDialogue.Length; i++)
        {
            if (skipDialogue) 
            {
                dialogueText.text = currentDialogue;
                break;
            }

            dialogueText.text += currentDialogue[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        skipDialogue = false;
    }
}

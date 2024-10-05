using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmasherUI : MonoBehaviour
{
    public GameObject smasher;
    public Slider healSlider;
    public Slider poisSlider;
    public Slider tempSlider;

    private StateManager stateManager;
    private GameObject mixedMed;
    private bool canMove;
    private bool isMoved;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        setSliderValue();
        canmove();
        if (stateManager.state == 1 && !isMoved&&canMove)
        {
            LeanTween.moveLocalY(gameObject, -300, 1).setEaseInOutCubic();
            isMoved = true;
        }
        else if (stateManager.state != 1 && isMoved)
        {
            LeanTween.moveLocalY(gameObject, -800, 1).setEaseInOutCubic();
            isMoved = false;
        }
    }

    private void canmove()
    {
        if(smasher.transform.childCount != 0)
        {
            if (smasher.transform.GetChild(0) != null)
            {
                mixedMed = smasher.transform.GetChild(0).gameObject;
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
    }

    private void setSliderValue()
    {
        if (mixedMed != null)
        {
            healSlider.value = mixedMed.GetComponent<BaseMed>().cure;
            poisSlider.value = mixedMed.GetComponent<BaseMed>().pois;
            tempSlider.value = mixedMed.GetComponent<BaseMed>().temp;
        }
    }
}

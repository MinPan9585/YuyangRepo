using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class MedMakingUI : MonoBehaviour
{
    public Slider healSlider;
    public Slider poisSlider;
    public Slider tempSlider;

    public bool canMove;
    private StateManager stateManager;
    private MedMaking medMaking;
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        medMaking = FindAnyObjectByType<MedMaking>();
    }

    void Update()
    {
        MoveUI();
        UpdateSliderValue();
    }

    private void UpdateSliderValue()
    {
        healSlider.value = medMaking.currentHeal;
        poisSlider.value = medMaking.currentPois;
        tempSlider.value = medMaking.currentTemp;
    }

    private void MoveUI()
    {
        if (canMove)
        {
            LeanTween.moveLocalY(tempSlider.gameObject, -310, 0.2f).setEaseInOutCubic();
            LeanTween.moveLocalY(gameObject, -20f, 0.2f).setEaseInOutCubic().setOnComplete(() =>
            {
                canMove = false;
            });
        }
    }
}

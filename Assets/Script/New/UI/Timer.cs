using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float roundTime;
    public float publicTimer;
    public bool startRound = false;

    [SerializeField] private Slider l_slider;
    [SerializeField] private Slider r_slider;
    private StateManager stateManager;
    private bool isMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = FindAnyObjectByType<StateManager>();
        resetTimeBar();
    }

    // Update is called once per frame
    void Update()
    {
        publicTimer -= Time.deltaTime;
        UpdateTimeBar();
        MoveTimer();
    }

    private void resetTimeBar()
    {
        l_slider.maxValue = roundTime;
        l_slider.value = roundTime;
        r_slider.maxValue = roundTime;
        r_slider.value = roundTime;
    }

    private void UpdateTimeBar()
    {
        if (startRound)
        {
            if (publicTimer>=0)
            {
                l_slider.value = publicTimer;
                r_slider.value = publicTimer;
            }
            else
            {
                l_slider.value = 0;
                r_slider.value = 0;
            }     
        }
    }

    private void MoveTimer()
    {
        if (startRound&&!isMoved)
        {
            LeanTween.moveLocalY(gameObject, 410, 0.2f).setOnComplete(() =>
            {
                isMoved = true;
                publicTimer = roundTime;
            });
        }
    }
}

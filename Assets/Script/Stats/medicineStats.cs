using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class medicineStats : MonoBehaviour
{
    public Stat powderValue;
    public Stat charValue;

    [HideInInspector] public List<string> symptoms;
    public int currentPowderValue;
    // Start is called before the first frame update
    public virtual void Start()
    {
        currentPowderValue = powderValue.GetValue();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void AddSymptom(string _symptom)
    {
        symptoms.Add(_symptom);
    }
}

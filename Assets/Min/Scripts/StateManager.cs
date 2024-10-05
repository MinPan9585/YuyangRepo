using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.Windows;

public class StateManager : MonoBehaviour
{
    public int state = 0;
    public GameObject mixedMed;
    public Transform bowl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            if(hit.collider != null)
            {
                if (state == 0)
                {
                    
                    if (hit.collider.gameObject.CompareTag("EndStateOne"))
                    {
                        state = 1;
                    }
                }

                if (state == 1)
                {
                    if (hit.collider.gameObject.CompareTag("BaseMed"))
                    {
                        AddIngredients(hit.collider.GetComponent<BaseMed>());
                    }
                    if (hit.collider.gameObject.CompareTag("EndStateTwo"))
                    {
                        state = 2;
                    }
                }

                if (state == 2)
                {
                    if (hit.collider.gameObject.CompareTag("Hammer"))
                    {
                        
                    }
                    //if (hit.collider.gameObject.CompareTag("AddWater"))
                    //{
                    // cool
                    //}
                    if (hit.collider.gameObject.CompareTag("EndStateThree"))
                    {
                        // end
                    }
                }

                if(state == 3)
                {
                    if (hit.collider.gameObject.CompareTag("Windbox"))
                    {
                        // warm
                    }
                    if (hit.collider.gameObject.CompareTag("EndStateFour"))
                    {
                        // end
                    }
                }
            }

            
        }
    }

    public void AddIngredients(BaseMed baseMed)
    {
        if (bowl.childCount > 0)
        {
            bowl.GetChild(0).GetComponent<BaseMed>().cure += baseMed.cure;
            bowl.GetChild(0).GetComponent<BaseMed>().temp += baseMed.temp;
            bowl.GetChild(0).GetComponent<BaseMed>().pois += baseMed.pois;
            foreach(string _symp in baseMed.symps)
            {
                if (!bowl.GetChild(0).GetComponent<BaseMed>().symps.Contains(_symp))
                    bowl.GetChild(0).GetComponent<BaseMed>().symps.Add(_symp);
            }
        }
        if (bowl.childCount == 0)
        {
            // instantiate prefab in the bowl
            GameObject mixed = Instantiate(mixedMed, bowl);

            // add cure, temp, and pois to the prefab
            mixed.GetComponent<BaseMed>().cure = baseMed.cure;
            mixed.GetComponent<BaseMed>().temp = baseMed.temp;
            mixed.GetComponent<BaseMed>().pois = baseMed.pois;
            mixed.GetComponent<BaseMed>().symps = baseMed.symps;
        }
        // play animation
    }

    public void UseHammer()
    {

    }
}

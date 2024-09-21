using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Roller roller;
    private Medicine medicine;
    private medicineStats medStats;

    // Start is called before the first frame update
    void Start()
    {
        roller = GetComponentInParent<Roller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Med") && roller.canWork)
        {
            medicine = collision.GetComponent<Medicine>();
            medStats = collision.GetComponent<medicineStats>();
            medicine.isMashed = true;
            medicine.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            StartCoroutine("PowderIncrease");
            Debug.Log("Smashing");
        }
    }

    private IEnumerator PowderIncrease()
    {
        Vector2 _targetVector = new Vector2(medicine.instantiatedPowder.transform.position.x, medicine.instantiatedPowder.transform.position.y + 0.05f);
        while (Vector2.Distance(medicine.instantiatedPowder.transform.position, _targetVector) <= 0.01f)
        {
            medicine.instantiatedPowder.transform.position = Vector2.Lerp(medicine.instantiatedPowder.transform.position, _targetVector, 0.01f);
            yield return null;
        }
        medicine.instantiatedPowder.transform.position = _targetVector;
        //Debug.Log("increased");
        yield break;
    }
}

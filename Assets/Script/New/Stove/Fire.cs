using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public WindBox windBox;
    public float publicTimer;

    [Header("Fire")]
    public float fireChangeSpeed = 0;
    public float fireChangeValue;
    public float increaseDelta;
    private Vector3 maxFireScale = new Vector3(2, 2, 2);
    private Vector3 minFireScale = new Vector3(1f, 1f, 1f);

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        publicTimer -= Time.deltaTime;
        IncreaseFireChangeRate();
        CalculateFireIncreaseSpeed();
        IncreaseFireScale();
    }
    #region FireFunctions
    private void IncreaseFireChangeRate()
    {
        if (windBox.rb.velocity.x != 0)
        {
            publicTimer = 2f;
            fireChangeSpeed = Mathf.MoveTowards(fireChangeSpeed, 10f, increaseDelta * Time.deltaTime);
        }
        else
        {
            fireChangeSpeed = Mathf.MoveTowards(fireChangeSpeed, 0f, increaseDelta * Time.deltaTime);
        }
    }

    private void CalculateFireIncreaseSpeed()
    {
        fireChangeValue = 0.5f * Mathf.Pow(fireChangeSpeed, 1.0f / 3.0f);
    }
    private void IncreaseFireScale()
    {
        if (windBox.rb.velocity.x != 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxFireScale, fireChangeValue * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position,new Vector3(0, -3.6f,0),fireChangeValue * Time.deltaTime);
        }
        else if ( windBox.rb.velocity.x == 0 && publicTimer <= 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, minFireScale, 0.1f * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, -4.3f, 0), 0.1f * Time.deltaTime);
        }
    }
    #endregion
}

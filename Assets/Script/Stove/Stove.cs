using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Stove : MonoBehaviour
{
    #region StateMachine
    public StoveStateMachine stateMachine { get; private set; }
    public stoveIdleState stoveIdleState { get; private set; }
    public stoveActiveState stoveActiveState { get; private set; }
    #endregion
    #region Components
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Vector3 mousePos;
    [HideInInspector] public WindBox windBox;
    [HideInInspector] public GameObject ins_Fire;
    [HideInInspector] public bool isFire;
     public float publicTimer;

    [Header("Fire")]
    public float fireChangeSpeed = 0;
    public float fireChangeValue;
    public float increaseDelta;
    private Vector3 maxFireScale = new Vector3(1,1,1);
    private Vector3 minFireScale = new Vector3(0.2f,0.2f,0.2f);

    public bool canActive;
    public GameObject fire;
    public Transform fireStartPoint;

    public List<GameObject> powders;
    #endregion 

    private void Awake()
    {
        #region stateAssignments
        stateMachine = new StoveStateMachine();
        stoveIdleState = new stoveIdleState(stateMachine, this);
        stoveActiveState = new stoveActiveState(stateMachine, this);
        #endregion
        #region ComponentsAssignments
        rb = GetComponent<Rigidbody2D>();
        GameObject _windBox = GameObject.Find("WindBox");
        windBox = _windBox.GetComponent<WindBox>();
        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {
        stateMachine.Initialize(stoveIdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
        publicTimer -= Time.deltaTime;
        FireFunctions();
        ActiveDetection();
    }
    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("M_powder"))
        {
            powders.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("M_powder"))
        {
            powders.Remove(collision.gameObject);
        }
    }
    #region FireInformation
    public void InstantiateFire()
    {
        if (!isFire)
        {
            ins_Fire = Instantiate(fire, fireStartPoint.position,fireStartPoint.rotation);
            isFire = true;
            windBox.canActiveWindBox = true;
        }
        else
        {
            Destroy(ins_Fire);
            isFire= false;
            windBox.canActiveWindBox= false;
        }
    }
    private void FireFunctions()
    {
        IncreaseFireChangeRate();
        CalculateFireIncreaseSpeed();
        IncreaseFireScale();
    }
    private void IncreaseFireChangeRate()
    {
        if (windBox.rb.velocity.x != 0)
        {
            publicTimer = 2f;
            fireChangeSpeed = Mathf.MoveTowards(fireChangeSpeed, 10f, increaseDelta*Time.deltaTime);
        }
        else
        {
            fireChangeSpeed = Mathf.MoveTowards(fireChangeSpeed, 0f, increaseDelta * Time.deltaTime);
        }
    }

    private void CalculateFireIncreaseSpeed()
    {
        fireChangeValue = 0.5f*Mathf.Pow(fireChangeSpeed, 1.0f / 3.0f);
    }
    private void IncreaseFireScale()
    {
        if(ins_Fire != null&& windBox.rb.velocity.x != 0)
        {
            ins_Fire.transform.localScale = Vector3.Lerp(ins_Fire.transform.localScale, maxFireScale, fireChangeValue * Time.deltaTime);
        }
        else if(ins_Fire != null&& windBox.rb.velocity.x == 0&&publicTimer <= 0)
        {
            ins_Fire.transform.localScale = Vector3.Lerp(ins_Fire.transform.localScale, minFireScale, 0.1f* Time.deltaTime);
        }
    }
    #endregion
    #region ActiveDetection
    private void ActiveDetection()
    {
        canBeActive("M_powder");
        cannotBeActive();
    }
    private void canBeActive(string Tag)
    {
        foreach (GameObject obj in powders)
        {
            if (obj != null && obj.CompareTag(Tag))
            {
                canActive =  true;
            }
        }
        
    }
    private void cannotBeActive()
    {
        if(powders.All(item => item == null))
        {
            canActive = false;
        }
    }
    #endregion
}

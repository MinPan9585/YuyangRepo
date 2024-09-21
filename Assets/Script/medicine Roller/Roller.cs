using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    #region StateMachine
    public RollerStateMachine stateMachine {  get; private set; }
    public RollerIdleState idleState { get; private set; }
    public RollerMoveState moveState { get; private set; }

    #endregion
    #region components
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Rigidbody2D stickRb;
    [HideInInspector] public Transform stick;
    [HideInInspector] public Transform stickPos;
    [HideInInspector] public Vector3 mousePos;
    public List<GameObject> Meds;
    #endregion

    public float resetSpeed;
    public float ActiveSpeed;

    [HideInInspector] public bool isActivated;
    public bool canWork;
    


    public void Awake()
    {
        #region State Assignments
        stateMachine = new RollerStateMachine();
        idleState = new RollerIdleState(stateMachine,this);
        moveState = new RollerMoveState(stateMachine, this);
        #endregion
        #region ComponentsAssignments
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isActivated = false;
        canWork = false;
        stick = transform.Find("stick");
        stickPos = transform.Find("stickPos");
        stickRb = stick.GetComponent<Rigidbody2D>();
        #endregion
    }
    void Start()
    {
        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
    }
    private void FixedUpdate()
    {
        stateMachine.currentState.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Med"))
        {
            if (!Meds.Contains(collision.gameObject))
            {
                Meds.Add(collision.gameObject);
            }
        }
    }

    
    #region IEnumerator
    private IEnumerator ResetStick()
    {
        while (Vector2.Distance(stick.position, stickPos.position) > 0.1f)
        {
            stick.position = Vector2.Lerp(stick.position, stickPos.position, resetSpeed * Time.deltaTime);
            yield return null;
        }
        stick.position = stickPos.position;
        yield break;
    }
    private IEnumerator ActiveStick()
    {
        stickRb.isKinematic = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        while (Vector2.Distance(stick.position, mousePosition) > 0.01f)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            stick.position = Vector2.Lerp(stick.position, mousePosition, ActiveSpeed * Time.deltaTime);
            stick.rotation = Quaternion.Lerp(stick.rotation,Quaternion.Euler(0,0,2), ActiveSpeed * Time.deltaTime);
            yield return null;
        }
        //stick.position = mousePosition;
        isActivated = true;
        yield break;
    }
    #endregion



}

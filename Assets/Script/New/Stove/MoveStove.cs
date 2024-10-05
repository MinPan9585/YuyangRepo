using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStove : MonoBehaviour
{
    public bool canMove;
    public GameObject mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            LeanTween.scale(gameObject, new Vector3(1.25f, 1.25f, 1.25f), 1).setEaseInOutCubic();
            LeanTween.moveX(gameObject, 5.8f, 1).setEaseInOutCubic();
            LeanTween.moveY(gameObject, 1.25f, 1).setEaseInOutCubic();
            mask.GetComponent<SpriteRenderer>().enabled = true;
            canMove = !canMove;
        }
    }
}

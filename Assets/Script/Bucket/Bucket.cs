using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public Transform pivot;
    public float resetDuration;
    private bool isDragging = false;
    private Vector3 lastMousePos;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
    }
    void Update()
    {
        RotateBucket();
    }

    private void RotateBucket()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lastMousePos.z = 0;

                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePos.z = 0;

            Vector3 lastDirection = lastMousePos - pivot.position;
            Vector3 currentDirection = currentMousePos - pivot.position;

            float angle = Vector3.SignedAngle(lastDirection, currentDirection, Vector3.forward);

            transform.RotateAround(pivot.position, Vector3.forward, angle);

            lastMousePos = currentMousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            StartCoroutine("ResetBucket");
        }
    }

    private IEnumerator ResetBucket()
    {
        float timeElapsed = 0f;
        Quaternion currentRotation = transform.rotation;
        Vector3 currentPosition = transform.position;

        while (timeElapsed < resetDuration)
        {
            transform.rotation = Quaternion.Slerp(currentRotation, initialRotation, timeElapsed / resetDuration);
            transform.position = Vector3.Slerp(currentPosition, initialPosition, timeElapsed / resetDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = initialRotation;
    }
}

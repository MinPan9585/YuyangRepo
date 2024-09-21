using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItems : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemPrefab;  
    private GameObject itemBeingDragged; 
    private Vector3 startPosition; 
    private Transform originalParent; 

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        startPosition = transform.position;
        originalParent = transform.parent;
        itemBeingDragged = Instantiate(gameObject, transform.parent);
        itemBeingDragged.transform.SetAsLastSibling(); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeingDragged.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsPointerOverUIObject())
        {
            Debug.Log("beginInstantiate");
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPos.z = 0;
            Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        }

        Destroy(itemBeingDragged); 
        transform.position = startPosition;
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        int castResults = results.Count;
        foreach (RaycastResult result in results)
        {
            if (!result.gameObject.CompareTag("IgnoreForDrag"))
            {
                castResults++;
            }
        }
        //Debug.Log(castResults);
        return results.Count > 1;
    }
}

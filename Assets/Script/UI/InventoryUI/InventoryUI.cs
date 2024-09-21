using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public Button toggleButton; 
    public GameObject itemPrefab;
    public Transform itemContainer;


    [SerializeField]private bool isOpen = false; 

    private void Start()
    {
        inventoryPanel.transform.localPosition = new Vector3(1210, 0, 0);

        toggleButton.onClick.AddListener(ToggleInventory);
    }


    public void ToggleInventory()
    {
        if (isOpen)
        {
            LeanTween.moveLocalX(inventoryPanel, 1210, 0.5f).setEaseInOutCubic();
            LeanTween.moveLocalX(toggleButton.gameObject, 940, 0.5f).setEaseInOutCubic();
        }
        else
        {
            LeanTween.moveLocalX(toggleButton.gameObject, 440, 0.5f).setEaseInOutCubic();
            LeanTween.moveLocalX(inventoryPanel, 710, 0.5f).setEaseInOutCubic();
        }
        isOpen = !isOpen;
    }

    public void AddItem(Sprite itemSprite)
    {
        GameObject newItem = Instantiate(itemPrefab, itemContainer);
        newItem.GetComponent<Image>().sprite = itemSprite;
    }
}

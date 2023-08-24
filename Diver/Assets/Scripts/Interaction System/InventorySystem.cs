using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    [Header("Компоненты")]
    public GameObject uiWindow;
    public Image[] itemsImage;
    public bool isOpen;

    [Header("Oписание предметов")]
    public GameObject uiDescriptionWindow;
    public Image descriptionImage;
    public TMP_Text desctiptionTitles;
    public TMP_Text desctiptionDescription;

    public void PickUp(GameObject item)
    {
         items.Add(item);
         UpdateUI();
    }

    private void UpdateUI()
    {
        HideAll();
        for (int i = 0; i < items.Count; i++)
        {
            itemsImage[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            itemsImage[i].gameObject.SetActive(true);
        }
    }

    void HideAll() 
    { 
        foreach (var item in itemsImage) { item.gameObject.SetActive(false); }
        HideDescription();
    }
 
    void ToggleInventory()
    {
        isOpen = !isOpen;
        uiWindow.SetActive(isOpen);
        UpdateUI();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ShowDescription(int id)
    {       
        descriptionImage.sprite = itemsImage[id].sprite;
        desctiptionTitles.text = items[id].name;
        desctiptionDescription.text = items[id].GetComponent<Item>().descriptionText;

        descriptionImage.gameObject.SetActive(true);
        desctiptionTitles.gameObject.SetActive(true);
        uiDescriptionWindow.gameObject.SetActive(true);
        desctiptionDescription.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        descriptionImage.gameObject.SetActive(false);
        desctiptionTitles.gameObject.SetActive(false);
        uiDescriptionWindow.gameObject.SetActive(false);
        desctiptionDescription.gameObject.SetActive(false);
    }
    public void Consume(int id)
    {
        if (items[id].GetComponent<Item>().itemType == Item.ItemType.Consumables)
        {      
            items[id].GetComponent<Item>().consumeEvent.Invoke();

            Destroy(items[id], 0.1f);

            items.Remove(items[id]);

            UpdateUI();
        }
    }
}

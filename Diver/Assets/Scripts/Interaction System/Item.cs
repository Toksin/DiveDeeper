using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{

    public enum InteractionType { NONE,PickUp,Examine}
    public enum ItemType { Static, Consumables}

    [Header("Атрибуты")]
    public InteractionType interactType;    
    public ItemType itemType;

    [Header("Описание")]
    public string descriptionText;

    [Header("События")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;

        Vector2 newSize = GetComponent<BoxCollider2D>().size;

        newSize.x *= 3f;
        newSize.y *= 3f;

        GetComponent<BoxCollider2D>().size = newSize;
    }

   public void Interact()
   {
        switch (interactType)
        {
            case InteractionType.PickUp:
               // GameObject item = gameObject;
                FindFirstObjectByType<InventorySystem>().PickUp(gameObject);      
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                FindFirstObjectByType<InteractionSystem>().ExamineItem(this);
                break;

            default:
                Debug.Log("Null item");
                break;
        }

        customEvent.Invoke();
   } 

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header("Настройка")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;

    [Header("Компоненты")]
    public GameObject detectedObject;

    [Header("Компоненты системы описания предметов")]
    public GameObject examineWindow;
    public Image examineImage;
    public TMP_Text examineText;
    public bool isExamining;

    [Header("Компоненты для поднятия предметов")]
    public bool isGrabbing;
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }   

    bool DetectObject()
    {       
           

        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer); 
        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }
  

    public void ExamineItem(Item item)
    {
        if(isExamining)
        {
            examineWindow.SetActive(false);
            isExamining = false;
        }
        else
        {
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);

            isExamining = true;
        }

       
    }

    public void GrabDrop()
    {
        if(isGrabbing)
        {
            isGrabbing = false;
            grabbedObject.transform.parent = null;
            grabbedObject.transform.position = new Vector3(grabbedObject.transform.position.x, grabbedObjectYValue, grabbedObject.transform.position.z);
            grabbedObject = null;
        }
        else
        {
            isGrabbing = true;
            grabbedObject = detectedObject;
            grabbedObject.transform.parent = transform;
            grabbedObjectYValue = grabbedObject.transform.position.y;
            grabbedObject.transform.localPosition = grabPoint.localPosition;
        }
    }

    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                if (isGrabbing)
                {
                    GrabDrop();
                    return;
                }
                detectedObject.GetComponent<Item>().Interact();
                AudioManager.instance.PlaySFX("take");
            }
        }
    }   
}

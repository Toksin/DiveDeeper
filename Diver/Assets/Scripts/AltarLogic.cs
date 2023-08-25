using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarLogic : MonoBehaviour
{
    [Header("Принесенные части тела")]
    public int bodyParts;    

   [Header("Ведра")]
   [SerializeField] private GameObject bucket1;
   [SerializeField] private GameObject bucket2;
   [SerializeField] private GameObject bucket3;
   [SerializeField] private GameObject bucket4;
   [SerializeField] private GameObject altarOn;
   [SerializeField] private GameObject altarOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BodyPart")
        {
            bodyParts++;

            collision.gameObject.SetActive(false);

            //Destroy(collision.gameObject);
        }
    }

    void ActivatePortals()
    {
        if(bodyParts == 2)
        {
            bucket1.SetActive(true);
        }
        else if(bodyParts == 4)
        {
            bucket2.SetActive(true);
        }
        else if (bodyParts == 6)
        {
            bucket3.SetActive(true);
        }
        else if(bodyParts == 8)
        {
            bucket4.SetActive(true);
        }
        else if(bodyParts == 10)
        {            
            altarOff.SetActive(false);
            altarOn.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePortals();
    }
}

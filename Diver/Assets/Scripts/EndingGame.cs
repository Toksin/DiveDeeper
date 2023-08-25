using UnityEngine;

public class EndingGame : MonoBehaviour
{
    [Header("Колличевство предметов для сбора")]
    [SerializeField] private int gems = 10;

    [Header("Колличевство принесенных игроком")]
    [SerializeField] private int gemsFromPlayer = 0;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = InventorySystem.inventorySystem.items.Count - 1; i >= 0; i--)
            {
                if (InventorySystem.inventorySystem.items[i].GetComponent<Item>().itemType == Item.ItemType.Static)
                {
                    gemsFromPlayer++;

                    InventorySystem.inventorySystem.items[i].GetComponent<Item>().consumeEvent.Invoke();

                    Destroy(InventorySystem.inventorySystem.items[i], 0.1f);


                    InventorySystem.inventorySystem.items.RemoveAt(i);
                    //InventorySystem.inventorySystem.items.Remove(InventorySystem.inventorySystem.items[i]);

                    InventorySystem.inventorySystem.UpdateUI();
                }               
               
            }           
            
        }
    }

    void CheckAmountGems()
    {
        if(gems <= gemsFromPlayer && FindFirstObjectByType<AltarLogic>().bodyParts == 10)
        {
            Debug.Log("Пабеда");
        }
        else if(gems <= gemsFromPlayer)
        {
            Debug.Log("Пабеда -1");
        }
    }
   
    void Update()
    {
        CheckAmountGems();
    }
}

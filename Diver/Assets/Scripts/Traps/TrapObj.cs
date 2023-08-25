using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TrapObj : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Reset()
    {
        
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetBool("isActive", true);
            FindFirstObjectByType<LifeCount>().LoseLife();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("isActive", false);            
        }
    }

}

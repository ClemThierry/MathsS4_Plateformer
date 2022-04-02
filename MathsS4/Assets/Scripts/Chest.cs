using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isInRange = false;

    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
            Debug.Log("Tu as gagné "+nbCoinWin()+" pièces.");
        }
        
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private int nbCoinWin()
    {
       double nb = Random.Range(0f, 1f);

        if (nb <= 0.6)
        {
            return 1;
        }
        else
        {
            return 3;
        }
    }
}

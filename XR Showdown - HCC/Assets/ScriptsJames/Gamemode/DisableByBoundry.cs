using UnityEngine;

public class DisableByBoundry : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Enemy Object")
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Health Object")
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Objective")
        {
            collision.gameObject.SetActive(false);
        }
    }
}

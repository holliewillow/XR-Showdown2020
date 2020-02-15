using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Object")
        {
            gameObject.SetActive(false);
        }
    }
}

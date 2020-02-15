using UnityEngine;

public class Damage : MonoBehaviour
{
    [Range(1,10)]
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Object")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Player Object")
        {
            gameObject.SetActive(false);
        }
    }
}

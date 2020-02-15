using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float BG_Speed = .01f;
    public bool left = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 new_pos = new Vector3(transform.position.x + BG_Speed, transform.position.y, transform.position.z);
        if (left) new_pos = new Vector3(transform.position.x - BG_Speed, transform.position.y, transform.position.z);
        transform.position = new_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Object")
        {
            gameObject.SetActive(false);
        }
    }
}
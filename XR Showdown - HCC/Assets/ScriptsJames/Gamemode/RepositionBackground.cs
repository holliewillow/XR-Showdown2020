using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBackground : MonoBehaviour
{
    private BoxCollider2D background_collider;
    private float background_horizontal_length;
    // Start is called before the first frame update
    void Start()
    {
        background_collider = GetComponent<BoxCollider2D>();
        background_horizontal_length = background_collider.size.x;
    }


    void Update()
    // Update is called once per frame
    {
     if(transform.position.x <  - background_horizontal_length)
        {
            repositionBackground();
        }
    }

    void repositionBackground()
    {
        Vector3 background_offset = new Vector3(background_horizontal_length * 2f, 0, 0);
        transform.position = (Vector3)transform.position + background_offset;
    }
}

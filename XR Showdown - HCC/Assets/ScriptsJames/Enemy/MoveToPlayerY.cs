using UnityEngine;

public class MoveToPlayerY : MonoBehaviour
{
    public GameObject Player;

    [Range(0.1f, 10.0f)]
    public float Move_Speed;

    [Range(0.1f, 10.0f)]
    public double Move_To_Margin;

    Rigidbody2D rb;
    double y_offset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 new_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        y_offset = transform.position.y - Player.transform.position.y;
        if (y_offset > Move_To_Margin) transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Player.transform.position.y), Move_Speed * Time.deltaTime);
        if (y_offset < Move_To_Margin*-1) transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Player.transform.position.y), Move_Speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, Player.transform.position.y), Move_Speed * Time.deltaTime);
        //transform.position = new_pos;
    }
}

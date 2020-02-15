using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_2D;
    private Stats.PlayerStats player_stats;

    public Boundary boundary;
    public Transform shotSpawn;
    public GameManager manager;

    private float next_fire;
    private float input_horizontal = 0;
    private float input_vertical = 0;
    
    [Range(1, 10)]
    public int player_health_amount;
    [Range(0.5f, 10.0f)]
    public float speed_movement = 0.1f;
    [Range(0.5f, 10.0f)]
    public float fireRate;

    private void Start()
    {
        rb_2D = GetComponent<Rigidbody2D>();
        player_stats = GetComponent<Stats.PlayerStats>();
        player_stats.Player_health = player_health_amount;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer(input_horizontal, input_vertical);
    }

    private void GetPlayerInput()
    {
        input_horizontal = Input.GetAxisRaw("Horizontal");
        input_vertical = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButton("Fire1") && Time.time > next_fire)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void MovePlayer(float input_horizontal, float input_vertical)
    {
        Vector3 direction = new Vector3(input_horizontal, input_vertical, 0);
        rb_2D.velocity = direction.normalized * speed_movement;
        
        rb_2D.position = new Vector3
        (
            Mathf.Clamp(rb_2D.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb_2D.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

    void Shoot()
    {
        next_fire = Time.time + fireRate;
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");

        if (bullet != null)
        {
            bullet.transform.position = shotSpawn.transform.position;
            bullet.transform.rotation = shotSpawn.transform.rotation;
            bullet.SetActive(true);
        }
    }

    public void ChangePlayerHealth(Stats.PlayerStats stats, int mod)
    {
        stats.ModifyPlayerHealth(mod);
    }

    private int score_amount = -1;
    private int damage_amount = -1;
    private int heal = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy Object")
        {
            player_stats.ModifyPlayerHealth(damage_amount);
        }

        if (collision.gameObject.tag == "Health Object")
        {
            player_stats.ModifyPlayerHealth(heal);
        }

        if (collision.gameObject.tag == "Objective")
        {
            manager.score_player += score_amount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            player_stats.ModifyPlayerHealth(damage_amount);
        }
    }
}
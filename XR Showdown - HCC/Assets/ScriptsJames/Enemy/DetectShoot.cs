using UnityEngine;

public class DetectShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject spawn_object;
    public Transform shotSpawn;

    public float sprite_width = 0;
    public bool can_shoot = true;
    public float can_shoot_margin = 1;
    public float time_between_shots = .05f;

    private float next_fire;
    float timer = 0;

    [Range(0.5f, 10.0f)]
    public float fireRate;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) can_shoot = true;
        float y_offset = player.transform.position.y - transform.position.y;
        if (y_offset < can_shoot_margin && y_offset > -can_shoot_margin)
        {
            if (can_shoot == true) Shoot();
        }

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
        can_shoot = false;
        timer = time_between_shots;
    }
}

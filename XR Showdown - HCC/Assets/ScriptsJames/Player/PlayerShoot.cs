using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Shoot();
    }

    void Shoot()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");
        if (bullet != null)
        {
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true);
        }
    }

    void DestroyByBoundry()
    {
        if (gameObject.tag == "Boundary")
        {
            if (gameObject.tag == "Player Bullet")
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
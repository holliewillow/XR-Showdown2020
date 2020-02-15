using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Transform> waypoint;
    public float spawn_delay;
    public int number_to_spawn;

    private void Start()
    {
        StartCoroutine(SpawnWaves(waypoint));
    }

    IEnumerator SpawnWaves(List<Transform> target)
    {
        yield return new WaitForSeconds(spawn_delay);

        while (true)
        {
            for (int i = 0; i < number_to_spawn; i++)
            {
                GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("Enemy Object");
                GameObject health = ObjectPooler.SharedInstance.GetPooledObject("Health Object");
                GameObject objective = ObjectPooler.SharedInstance.GetPooledObject("Objective");
                int n = Random.Range(0, waypoint.Count);

                float randValue = Random.value;
                if (randValue < .45f) // 45% of the time
                {
                    if (enemy != null)
                    {
                        enemy.transform.position = target[n].transform.position;
                        enemy.transform.rotation = target[n].transform.rotation;
                        enemy.SetActive(true);
                    }
                }
                else if (randValue < .9f) // 45% of the time
                {
                    if (objective != null)
                    {
                        objective.transform.position = target[n].transform.position;
                        objective.transform.rotation = target[n].transform.rotation;
                        objective.SetActive(true);
                    }
                }
                else // 10% of the time
                {
                    if (health != null)
                    {
                        health.transform.position = target[n].transform.position;
                        health.transform.rotation = target[n].transform.rotation;
                        health.SetActive(true);
                    }
                }//end of if, else if, else
            }//end of for loop
            yield return new WaitForSeconds(spawn_delay);
        }
    }
}

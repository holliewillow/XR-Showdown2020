using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [Header("Game Objects to Manage")]
    public PlayerController player;
    public Stats.PlayerStats stats;
    public GameObject auntie_anne;

    public int score_player = 5;
    public int score_required = 0;

    private void Awake()
    {
        if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
    }

    private void Update()
    {
        if (LoseCondition(stats))
        {
            ResetLevel();
        }
        WinCondition(score_player, score_required);
    }

    public bool LoseCondition(Stats.PlayerStats stats)
    {
        if (stats.Player_health == 0)
        {
            player.gameObject.SetActive(false);
            auntie_anne.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    public bool WinCondition(int score, int score_max)
    {
        if (score == score_max)
        {
            player.gameObject.SetActive(false);
            auntie_anne.gameObject.SetActive(false);
            Debug.Log("Winner");
            return true;
        }
        return false;
    }

    void ResetLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator RestartCondition(float spawn_delay)
    {
        yield return new WaitForSeconds(spawn_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
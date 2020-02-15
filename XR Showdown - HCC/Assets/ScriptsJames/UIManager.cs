using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{

    public static UIManager main;

    [Header("Manage Objective Score UI")]
    public GameManager manager;

    [Header("Manage UI Panels")]
    public GameObject panel_dynamic;

    [Header("Single Character UI Settings")]
    public Stats.PlayerStats stats;
    public Image progress_bar_image;

    [Header("Gameplay UI Settings")]
    public TextMeshProUGUI text_gameover;
    [TextArea]
    public string gameover_message;
    public TextMeshProUGUI text_objective;
    [TextArea]
    public string objective_message;
    public TextMeshProUGUI text_score;
    [TextArea]
    public string winner_message;
    public TextMeshProUGUI text_winner_message;

    private void Awake()
    {
        // Check if more than one R.Managers exist
        if (main != null && main != this)
        {
            Destroy(gameObject);
            return;
        }
        main = this;
        panel_dynamic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Dynamic UI
        DisplayDynamicUI(stats, progress_bar_image);

        // Static UI
        DisplayObjectiveMessage(text_objective, text_score);

        if (stats.Player_health <= 0)
        {
            DisplayGameoverUI(text_gameover);
        }
        else if (manager.score_player == manager.score_required)
        {
            DisplayGameoverUI(text_gameover);
        }
    }

    void DisplayDynamicUI(Stats.PlayerStats stats, Image progress_bar_image)
    {
        progress_bar_image.fillAmount = (float)stats.Player_health / 10.0f;
    }

    void DisplayGameoverUI(TextMeshProUGUI text_gameover)
    {
        if (manager.LoseCondition(stats)) text_gameover.text = gameover_message;
        if (manager.WinCondition(manager.score_player, manager.score_required)) text_gameover.text = winner_message;
        panel_dynamic.SetActive(true);
    }

    void DisplayObjectiveMessage(TextMeshProUGUI text_objective, TextMeshProUGUI text_score)
    {
        text_objective.text = objective_message;
        text_score.text = manager.score_player.ToString();
    }
}

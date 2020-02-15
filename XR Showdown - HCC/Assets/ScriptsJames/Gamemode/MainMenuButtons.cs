using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button play_button, quit_button;
    public string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        play_button.onClick.AddListener(open_level);
        quit_button.onClick.AddListener(exit);
    }

    void open_level()
    {
        SceneManager.LoadScene(scene_name);
    }

    void exit()
    {
        Application.Quit();
    }
}

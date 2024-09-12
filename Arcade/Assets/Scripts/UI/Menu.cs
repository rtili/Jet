using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text _bestScore;

    void Start()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            _bestScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
        else
            _bestScore.text = "0";
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

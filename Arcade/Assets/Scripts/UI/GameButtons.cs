using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}

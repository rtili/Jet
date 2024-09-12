using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Text _stateText;
    [SerializeField] private AudioClip _success;
    [SerializeField] private Sprite _sprite;

    private AudioSource _audioSource;

    void Start()
    {
        _timer.Win += ShowWinScreen;
        _audioSource = GetComponent<AudioSource>();
    }

    private void ShowWinScreen()
    {
        _audioSource.PlayOneShot(_success);
        _screen.SetActive(true);
        _screen.GetComponent<Image>().sprite = _sprite;
        _stateText.text = "Win";
        _stateText.color = Color.green;
        Time.timeScale = 0;
        _timer.Win -= ShowWinScreen;
    }
}

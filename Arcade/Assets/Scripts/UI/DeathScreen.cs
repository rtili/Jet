using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Text _stateText;
    [SerializeField] private AudioClip _fail;
    [SerializeField] private Sprite _sprite;

    private AudioSource _audioSource;
    
    void Start()
    {
        _playerHealth.Death += ShowDeathScreen;
        _audioSource = GetComponent<AudioSource>();
    }

    private void ShowDeathScreen()
    {
        _audioSource.PlayOneShot(_fail);
        _screen.SetActive(true);
        _screen.GetComponent<Image>().sprite = _sprite;
        _stateText.text = "Lose";
        _stateText.color = Color.red;
        Time.timeScale = 0;
        _playerHealth.Death -= ShowDeathScreen;
    }
}

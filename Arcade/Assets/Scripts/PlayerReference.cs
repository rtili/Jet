using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    public PlayerScore PlayerScore { get { return _playerScore; } }
    public static PlayerReference Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}

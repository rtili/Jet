using UnityEngine;

public class EnemyScore : MonoBehaviour, IGiveScore
{
    [SerializeField] private int _score;
    private PlayerScore _playerScore;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _playerScore = PlayerReference.Instance.PlayerScore;
        _enemyHealth.Death += GiveScore;
    }

    public void GiveScore()
    {
        _playerScore.GetComponent<ISetScore>().GetScore(_score);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour, ISetScore
{
    [SerializeField] private Text _scoreAmount;
    private int _maxScore;
    private int _score = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        if (PlayerPrefs.HasKey("MaxScore"))        
            _maxScore = PlayerPrefs.GetInt("MaxScore");        
        else        
            _maxScore = 0;        
    }

    public void GetScore(int score)
    {
        _score += score;
        PlayerPrefs.SetInt("Score", _score);
        if (_score > _maxScore)        
            PlayerPrefs.SetInt("MaxScore", _score);       
        OnScoreChanged();
    }

    private void OnScoreChanged()
    {
        _scoreAmount.text = _score.ToString();
    }
}

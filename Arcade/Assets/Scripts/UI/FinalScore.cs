using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private Text _maxScore;
    [SerializeField] private GameObject _screen;

    private void Update()
    {
        if (_screen.activeInHierarchy)
        {
            _score.text = PlayerPrefs.GetInt("Score").ToString();
            _maxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
        }
    }
}

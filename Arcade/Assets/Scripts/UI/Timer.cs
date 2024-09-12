using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timer;
    [SerializeField] private float _timeToWin;
    public Action Win;
    private float _time;

    void Update()
    {
        _time += Time.deltaTime;
        _timer.text = _time.ToString("0.00");

        if (_time >= _timeToWin)
            Win?.Invoke();
    }
}

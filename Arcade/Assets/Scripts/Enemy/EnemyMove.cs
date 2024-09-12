using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        StartState();
    }

    private void StartState()
    {
        _animator = GetComponent<Animator>();
        int random = Random.Range(1, 4);
        _animator.SetInteger("State", random);
    }

    private void OnEnable()
    {
        StartState();
    }
}

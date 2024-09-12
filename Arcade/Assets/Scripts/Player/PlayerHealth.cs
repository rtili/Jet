using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable, IDeath
{
    [SerializeField] private int _maxHealth;
    public Action Death;
    private int _health;

    void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Dead();
    }

    public void Dead()
    {
        Death?.Invoke();
    }
}

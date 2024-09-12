using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IDeath
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private AudioClip _death;
    [SerializeField] private ParticleSystem _explosion;

    public Action Death;
    private int _health;
    

    void Start()
    {
        _health = _maxHealth;
    }
    private void OnEnable()
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
        AudioSource.PlayClipAtPoint(_death, transform.position);
        Instantiate(_explosion, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damage))
        {
            damage.TakeDamage(_damage);
        }
        gameObject.SetActive(false);
    }
}

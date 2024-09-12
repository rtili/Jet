using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _delay;

    private float _raycastDistance = 15;
    private float _timeToShoot;
    private LayerMask _playerLayerMask;

    private void Start()
    {
        _playerLayerMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        _timeToShoot -= Time.deltaTime;
        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, _raycastDistance, _playerLayerMask))
        {
            if (_timeToShoot <= 0)
            {
                Shoot();
                _timeToShoot = _delay;
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = ObjectPool.Instance.SpawnFromPool("EnemyBullet", _projectileSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.back * _projectileSpeed, ForceMode.VelocityChange);
    }
}

using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _delay;
    [SerializeField] private AudioClip _shot;

    private AudioSource _audioSource;
    private float _raycastDistance = 15;
    private float _timeToShoot;
    private LayerMask _enemyLayerMask;

    private void Start()
    {
        _enemyLayerMask = LayerMask.GetMask("Enemy");
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _timeToShoot -= Time.deltaTime;
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, _raycastDistance, _enemyLayerMask))
        {
            if (_timeToShoot <= 0)
            {
                Shoot();
                _timeToShoot = _delay;
                _audioSource.PlayOneShot(_shot);
            }           
        }
    }

    private void Shoot()
    {
        GameObject projectile = ObjectPool.Instance.SpawnFromPool("Bullet", _projectileSpawnPoint.position, Quaternion.Euler(new Vector3(0, 90, 90)));
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * _projectileSpeed, ForceMode.VelocityChange);
    }
}

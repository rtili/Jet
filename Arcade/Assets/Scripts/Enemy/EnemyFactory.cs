using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private float _spawnDelay;

    private float _timeToSpawn;

    private void Start()
    {
        _timeToSpawn = _spawnDelay;
    }

    void Update()
    {
        _timeToSpawn -= Time.deltaTime;
        if (_timeToSpawn <= 0)
        {
            Spawn();
            _timeToSpawn = _spawnDelay;
        }
    }

    private void Spawn()
    {
        ObjectPool.Instance.SpawnFromPool("Enemy", _enemySpawnPoint.position, Quaternion.identity);
    }
}

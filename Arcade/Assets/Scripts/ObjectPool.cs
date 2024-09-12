using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        [SerializeField] private string _tag;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _size;

        public int Size { get { return _size; } }
        public GameObject Prefab { get { return _prefab; } }
        public string Tag { get { return _tag; } }
    }

    [SerializeField] private List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;

    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            _poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
            return null;

        GameObject objToSpawn = _poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        _poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _direction;

    private void Update()
    {
        _direction.x = Input.acceleration.x;
        if (_direction.sqrMagnitude > 1)
            _direction.Normalize();
        _direction *= Time.deltaTime;

        if (!Physics.Raycast(transform.position, _direction, 1f))
        {
            transform.position += _direction * _speed;
        }        
    }
}

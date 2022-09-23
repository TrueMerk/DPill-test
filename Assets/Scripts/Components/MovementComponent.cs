using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _movementSpeed = 3;
    [SerializeField] private int _rotationSpeed = 100;
    
    public void Move(Vector3 direction)
    {
        _rb.velocity = direction * _movementSpeed;
    }

    public void Rotate(Quaternion target)
    {
        Quaternion.Lerp(transform.rotation, target, Time.deltaTime * _rotationSpeed);
    }
}
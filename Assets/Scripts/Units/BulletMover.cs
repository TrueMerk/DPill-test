using System;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed ;
    private float _bulletSpeed;

    private void Start()
    {
        _bulletSpeed = _speed;
    }

    private void Update()
    {
        transform.Translate(0,0 ,_bulletSpeed);
    }
    
    private void OnEnable()
    {
        _bulletSpeed = _speed;
    }

    private void OnDisable()
    {
        _bulletSpeed = 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private int _realSpeed = 3;

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        _rb.velocity = direction * _realSpeed;
        if (_rb.velocity != Vector3.zero)
        {
            _animator.Play("Running");
        }
        else
        {
            _animator.Play("Dynamic Idle");
        }
    }
}

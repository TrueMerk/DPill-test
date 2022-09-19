using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Animator _animator;
    [SerializeField] private Movement _mover;
    [SerializeField] private int _realSpeed = 3;
    
    public float speed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _mover.Move(_object,_realSpeed);
             _animator.Play("Running");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _mover.Move(_object,-_realSpeed);
            _animator.Play("Running");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _mover.MoveSide(_object,_realSpeed);
            _animator.Play("Running");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _mover.MoveSide(_object,-_realSpeed);
            _animator.Play("Running");
        }
        else
        {
            _animator.Play("Dynamic Idle");
        }
    }
    
}

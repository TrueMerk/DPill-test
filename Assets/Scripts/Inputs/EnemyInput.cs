using System;
using UnityEngine;

public class EnemyInput : InputComponent
{
    [SerializeField] private float _attackDistance = 1;
    private Player _player;
    
    // https://answers.unity.com/questions/1199286/start-and-update-execution-issue.html 
    // беру в OnEnable из-за пула и префаба.
    private void OnEnable()
    {
        _player = ServiceLocator.Instance.GetService<Player>();
    }
    
    public override Vector3 GetMovementDirection()
    {
        var difference = _player.transform.position - transform.position;
        if (difference.magnitude <= _attackDistance || _player.IsOnBase || _player.IsDead)
        {
            return Vector3.zero;
        }
        return difference;
    }

    public override Quaternion GetRotation()
    {
        var playerPosition = _player.transform.position;
        var difference = playerPosition - transform.position;
        var rotateZ = Math.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
        var target = Quaternion.Euler(0f, ((float) (rotateZ)), 0f);
        return target;
    }

    public override bool IsAttacking()
    {
        var playerPosition = _player.transform.position;
        var difference = playerPosition - transform.position;
        return difference.magnitude <= _attackDistance;
    }
}

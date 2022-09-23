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
        if (Difference().magnitude <= _attackDistance || _player.IsOnBase || _player.IsDead)
        {
            return Vector3.zero;
        }
        return Difference();
    }

    public override Quaternion GetRotation()
    {
        var target = Quaternion.identity;
        if (Difference().magnitude>1)
        {
            var rotateZ = Math.Atan2(Difference().x, Difference().z) * Mathf.Rad2Deg;
            target = Quaternion.Euler(0f,(float) rotateZ,0f);
        }
        return Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
    }

    public override bool IsAttacking()
    {
        return Difference().magnitude <= _attackDistance;
    }

    private Vector3 Difference()
    {
        var playerPosition = _player.transform.position;
        return playerPosition - transform.position;
    }
}

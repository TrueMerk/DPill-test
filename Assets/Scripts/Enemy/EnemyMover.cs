using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animation;
    private void Update()
    {
        var transformPosition = ServiceLocator.Instance.GetService<PlayerInput>().transform.position;
        var difference = transformPosition - this.transform.position;
            if ((transformPosition.z>-7)&&(difference.magnitude>1))
            {
                var rotateZ = Math.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
                var target = Quaternion.Euler(0f,((float) (rotateZ)),0f);
                this.transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
                _movement.Move(this.gameObject,_speed);
                _animation.Play("Running");
            }
            else  if(difference.magnitude>1)
            {
                _animation.Play("Drunk Idle Variation");
            }
            else 
            {
                _animation.Play("Throw");
            }
    }
}

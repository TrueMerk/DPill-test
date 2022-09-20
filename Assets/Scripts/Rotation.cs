using System;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = ServiceLocator.Instance.GetService<Player>();
    }

    private void Update()
    {
        var transformPosition = _player.transform.position;
        var difference = transformPosition - transform.position;
        if (transformPosition.z>-7 && difference.magnitude>1)
        {
            var rotateZ = Math.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(0f,((float) (rotateZ)),0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
        }
        
    }
}
using System;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private BulletPool _bullet;
    [SerializeField] public Transform _shotDir;
    [SerializeField] private float _shootRate;
    private GameObject _playerPos;
    
    private float _reload;

    private void Start()
    {
        _reload = 2;
    }

    private void Update()
    {
        Shoot();
        
        if (_reload > 0)
        {
            _reload -= Time.deltaTime;
        }

        if (_reload < 0)
        {
            _reload = 0;
        }
    }
    
    private void Shoot()
    {
        if (ServiceLocator.Instance.GetService<EnemyPool>().EnemyList.Count != 0)
        {
            var differenceMin = Target();
            var rotateZ = Math.Atan2(differenceMin.x, differenceMin.z) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(0f,((float) (rotateZ)),0f);
            _shotDir.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
            if (_reload == 0)
            {
                _bullet.CreateBullet(_shotDir);
                _reload = _shootRate;
            }
        }
    }

    private Vector3 Target()
    {
        var transformPositionFirst = ServiceLocator.Instance.GetService<EnemyPool>().EnemyList[0].transform.position;
        var differenceMin = transformPositionFirst - this.transform.position;
        foreach (var Enemy in ServiceLocator.Instance.GetService<EnemyPool>().EnemyList)
        {
            var transformPosition = Enemy.transform.position;
            var difference = transformPosition - this.transform.position;
            if (difference.magnitude < differenceMin.magnitude)
            {
                differenceMin = difference;
            }
        }
        return differenceMin;
    }
}

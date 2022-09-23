using System;
using System.Collections;
using UnityEngine;

public class PlayerShooter : AttackComponent
{
    [SerializeField] private BulletPool _bullet;
    [SerializeField] public Transform _shotDir;
    [SerializeField] private float _shootRate;
    private GameObject _playerPos;
    private bool _isReload;
    private EnemyPool _enemyPool;
    private Player _player;
    private bool _enemyExist;

    public override bool CanAttack => !_isReload && !_player.IsOnBase && _enemyPool.EnemyExist;
    
    private void Start()
    {
        _player = ServiceLocator.Instance.GetService<Player>();
        _enemyPool = ServiceLocator.Instance.GetService<EnemyPool>();
    }
    
    private void Shoot()
    {
        
        if (_enemyPool.EnemyList.Count != 0)
        {
            var differenceMin = Target();
            var rotateZ = Math.Atan2(differenceMin.x, differenceMin.z) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(0f,((float) (rotateZ)),0f);
            _shotDir.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 100);
            _bullet.CreateBullet(_shotDir);
            StartCoroutine(Reload());
        }
        else
        {
            _enemyPool.EnemyExist = false;
        }
    }

    private IEnumerator Reload()
    {
        _isReload = true;
        yield return new WaitForSeconds(_shootRate);
        _isReload = false;
    }
    
    private Vector3 Target()
    {
        var transformPositionFirst = _enemyPool.EnemyList[0].transform.position;
        var differenceMin = transformPositionFirst - transform.position;
        foreach (var Enemy in _enemyPool.EnemyList)
        {
            var transformPosition = Enemy.transform.position;
            var difference = transformPosition - transform.position;
            if (difference.magnitude < differenceMin.magnitude)
            {
                differenceMin = difference;
            }
        }
        return differenceMin;
    }

    public override void Attack()
    {
        if (!_isReload)
        {
            Shoot();
        }
    }
}

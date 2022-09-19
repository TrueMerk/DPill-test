using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 2;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Health _enemy;
    [SerializeField] private int _spawnRate;
    public List<Health> EnemyList = new List<Health>();
    private Pool <Health> _pool;
    
    private void Start()
    {
        _pool = new Pool <Health> (_enemy, _poolCount, transform)
        {
            AutoExpand = _autoExpand
        };
        
        StartCoroutine(SpawnEnemyCoroutine(_spawnRate));
    }

   

    private void CreateEnemy()
    {
        var rX = Random.Range(-12f, 11f);
        var rZ = Random.Range(-5.5f,11f);
        
        var rPosition = new Vector3(rX, -1.5f, rZ);
        var rRotation = Quaternion.Euler(0, 180, 0);
        var enemy = _pool.GetFreeElement();
        enemy.transform.position = rPosition;
        ServiceLocator.Instance.GetService<EnemyPool>().EnemyList.Add(enemy);
       

    }
    
    private IEnumerator SpawnEnemyCoroutine(float rate)
    {
        
        while (true)
        {
            
            if (ServiceLocator.Instance.GetService<EnemyPool>().EnemyList.Count == 0 )
            {
                EnemyList.Clear();
                for (var i = 0; i < _poolCount; i++)
                {
                    CreateEnemy();
                    GameData._enemyCounter++;
                    var transformPosition = ServiceLocator.Instance.GetService<SpawnBonus>();
                }

                _poolCount++;
            }
            
            yield return new WaitForSeconds(rate);
        }
        
        // ReSharper disable once IteratorNeverReturns
    }

}
using System;
using UnityEngine;
using DefaultNamespace;
public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    private int _startHealth ;
    public event Action _dead;

    private void Awake()
    {
        _startHealth = _health;
    }
    
    private void OnEnable()
    {
        _health = _startHealth;
    }

    public void TookDamage()
    {
        if (_health >1)
            _health--;
        else
        {
            _health--;
            _dead?.Invoke();
            this.gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<EnemyPool>().EnemyList.Remove(this);
            GameData._enemyCounter--;
        }
    }
}

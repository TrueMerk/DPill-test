using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Tooltip("Шанс в процентах")][SerializeField] private float _chance;
    private BonusPool _bonusPool;

    private void Start()
    {
        _health.Dead += SpawnBonus;
        _bonusPool = ServiceLocator.Instance.GetService<BonusPool>();
    }

    private void SpawnBonus()
    {
        var randomChance = Random.Range(0f, 100f);
        if (randomChance < _chance)
        {
            if(_bonusPool!=null)
                _bonusPool.CreateBonus(transform);
        }
    }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Tooltip("Шанс в процентах")][SerializeField] private float _chance;
    

    private void Start()
    {
        _health._dead += SpawnBonus;
    }

    private void SpawnBonus()
    {
        var rX = Random.Range(0f, 100f);
        if (rX < _chance)
        {
            if(ServiceLocator.Instance.GetService<BonusPool>()!=null)
                ServiceLocator.Instance.GetService<BonusPool>().CreateBonus(this.transform);
        }
    }
    private void OnDisable()
    {
        // var rX = Random.Range(0f, 10f);
        // if (rX < 1f)
        // {
        //     if (ServiceLocator.Instance.GetService<BonusPool>() != null)
        //         ServiceLocator.Instance.GetService<BonusPool>().CreateBonus(this.transform);
        // }
    }
}
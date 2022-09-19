using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Bonus _bonus;
    private Pool<Bonus> _pool;
    public List<Bonus> BonusList;
    private void Start()
    {
        _pool = new Pool<Bonus>(_bonus, _poolCount, transform)
        {
            AutoExpand = _autoExpand
        };
    }

    public void CreateBonus(Transform shotDir)
    {
        var bullet = _pool.GetFreeElement();
        var o = bullet.gameObject;
        o.transform.position = shotDir.position;
        o.transform.rotation = shotDir.rotation;
    }
   
}

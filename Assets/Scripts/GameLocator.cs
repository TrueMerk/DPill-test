using UnityEngine;

public class GameLocator : MonoBehaviour
{
    [HideInInspector]public Transform player;
    [SerializeField] private EnemyPool _pool;
    private void Start()
    {
        ServiceLocator.Instance.GetService<EnemyPool>().GetComponent<EnemyPool>();
        ServiceLocator.Instance.GetService<PlayerInput>();
        ServiceLocator.Instance.GetService<BonusPool>();
    }
    
}

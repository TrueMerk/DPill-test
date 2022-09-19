using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    [SerializeField]private GameObject _bonus;
    public Health health;
    private void Start()
    {
        health._dead += Spawn;
    }

    private void Spawn()
    {
        //_bonus.SetActive(true);
       // Debug.Log("Бонус заспавлен");
    }
}

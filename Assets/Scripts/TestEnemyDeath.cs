using System;
using UnityEngine;

public class TestEnemyDeath : MonoBehaviour
{
    public event Action Die;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Die?.Invoke();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>()==null)
        {
            Die?.Invoke();
           
        }
        //Die?.Invoke();
    }
}

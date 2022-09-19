using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<JoyStickInput>();
        var health = other.GetComponent<Health>();
        if (player != null)
        {
            health.TookDamage();
        }
    }
}

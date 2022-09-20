using UnityEngine;

public class BulletDamageDealer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<JoyStickInput>();
        var health = other.GetComponent<Health>();
        if (player == null && health != null)
        {
            health.TookDamage();
        }
    }
}

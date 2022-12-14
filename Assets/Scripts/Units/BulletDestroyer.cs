using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<JoyStickInput>();
        if (player == null)
        {
            gameObject.SetActive(false);
        }
    }
}

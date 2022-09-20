using UnityEngine;

public class PlayerEnable : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.transform.position = new Vector3((float) -0.3, (float) -1.5, -10);
    }
}

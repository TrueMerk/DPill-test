using UnityEngine;

public class BaseEnabled : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _shotDir;
    private void Update()
    {
        if (_playerTransform.position.z< -7)
        {
            _shotDir.gameObject.SetActive(false);
        }
        else
        {
            _shotDir.gameObject.SetActive(true);
        }
    }
}

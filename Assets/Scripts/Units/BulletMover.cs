using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        transform.Translate(0,0 ,_speed);
    }
    
    private void OnEnable()
    {
        _speed = (float) 0.1;
       
    }

    private void OnDisable()
    {
        _speed = 0;
    }
}
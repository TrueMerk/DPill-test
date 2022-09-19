using System.Collections;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    
    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }

    private void OnDisable()
    {
        if (GetComponentInParent<Transform>() != null)
            transform.position = GetComponentInParent<Transform>().position;
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this._lifeTime);
        this.gameObject.SetActive(false);
    }
}
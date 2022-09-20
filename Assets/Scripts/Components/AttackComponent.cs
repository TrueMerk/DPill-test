using UnityEngine;

public abstract class AttackComponent : MonoBehaviour
{
    public abstract bool CanAttack { get; }
    public abstract void Attack();
}
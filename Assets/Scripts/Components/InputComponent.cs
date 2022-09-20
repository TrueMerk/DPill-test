using UnityEngine;

public abstract class InputComponent : MonoBehaviour
{
    public abstract Vector3 GetMovementDirection();

    public abstract Quaternion GetRotation();

    public abstract bool IsAttacking();

}
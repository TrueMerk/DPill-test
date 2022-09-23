using UnityEngine;

public class JoyStickInput : InputComponent
{
    [SerializeField] private Joystick _joystick;
    
    
    public override Vector3 GetMovementDirection()
    {
        return Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
    }

    public override Quaternion GetRotation()
    {
        return Quaternion.identity;
    }

    public override bool IsAttacking()
    {
        return !gameObject.GetComponent<Player>().IsOnBase;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move(GameObject gameObject, float speed)
    {
        gameObject.transform.Translate(0,0,(float) 0.02*speed);
    }
    
    public void MoveSide(GameObject gameObject, float speed)
    {
        gameObject.transform.Translate((float) 0.02*speed,0,0);
    }
}

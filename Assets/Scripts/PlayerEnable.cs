using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnable : MonoBehaviour
{
    private void OnDisable()
    {
        this.gameObject.transform.position = new Vector3((float) -0.3, (float) -1.5, -10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    public int health;

    private void Start()
    {
        _health._dead += Dead;
    }

    private void Dead()
    {
        health = 0;
    }
}

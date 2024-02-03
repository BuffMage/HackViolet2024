using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmogEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        speed = 1.5f;
        attackSpeed = 1f;
        strength = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

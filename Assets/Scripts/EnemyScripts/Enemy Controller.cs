using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private int health;
    private GameObject model;

    private float speed = 1.5f;

    private int strength;

    private Vector3 moveDirection = Vector3.left;

    private Rigidbody rb;

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int amount)
    {
        health -= amount;
    }

    public void Move()
    {
        this.transform.position += moveDirection * Time.deltaTime * speed;
    }

    public void attack()
    {
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    void Death()
    {
        Destroy(this.gameObject);
    }

}

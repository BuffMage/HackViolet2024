using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private int health = 10;
    private GameObject model;

    private float speed = 1.5f;

    private int strength;
    private float attackSpeed;

    private Vector3 moveDirection = Vector3.left;

    private Rigidbody rb;

    private int hitMask = 1 << 7;

    private bool isAttacking = false;

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Death();
        }
    }

    public void Move()
    {
        this.transform.position += moveDirection * Time.deltaTime * speed;
    }

    public void Attack()
    {
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("attackCycle");
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isAttacking)
        {
            Move();
        }
     

        
    }

    //need a coroutine for attacking interval
    private IEnumerator attackCycle()
    {
        while(isAttacking)
        {
            Attack();
            yield return new WaitForSeconds(attackSpeed);
        }

        //Unneccesary??
        yield return 0;
        
    }

    void Death()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            isAttacking = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isAttacking = false;
    }
   

}

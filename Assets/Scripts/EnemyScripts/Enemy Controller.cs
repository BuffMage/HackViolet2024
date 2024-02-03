using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    protected int health {get; set;}
    public GameObject model;

    protected float speed {get; set;}

    protected int strength {get; set;}
    protected float attackSpeed {get; set;}

    private Vector3 moveDirection = Vector3.left;

    private Rigidbody rb;

    private int hitMask = 1 << 7;

    private bool isAttacking = false;

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

    protected void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 10f, hitMask)) {
            // Will do more stuff later
            Debug.Log("Did-Hit");


            hit.transform.gameObject.GetComponent<TowerControl>().Damage(strength);

        }
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

        Debug.Log("AHHHHHHHHH");
    }

    void OnCollisionExit(Collision collision)
    {
        isAttacking = false;
    }
   

}

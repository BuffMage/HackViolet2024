using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health {get; set;}
    public GameObject model;

    [SerializeField] protected float speed {get; set;}

    [SerializeField] protected int strength {get; set;}
    [SerializeField] protected float attackSpeed {get; set;}

    private Vector3 moveDirection = Vector3.left;

    private Rigidbody rb;

    protected int hitMask = 1 << 7;

    protected bool isAttacking = false;

    private bool beingPushedBack = false;

    private Collider target;

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

    public void PushBack(float duration)
    {
        if (beingPushedBack) return;
        beingPushedBack = true;
        StartCoroutine(PushBackRoutine(duration));
    }

    public IEnumerator PushBackRoutine(float duration)
    {
        Debug.Log("Pushed back");
        float oldSpeed = speed;
        speed = speed / 2;
        yield return new WaitForSeconds(duration);
        speed = oldSpeed;
        beingPushedBack = false;
    }

    protected virtual void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.right, Vector3.left, out hit, 10f, hitMask)) {
            // Will do more stuff later
            Debug.Log("Did-Hit: Enemy");


            hit.transform.gameObject.GetComponent<TowerControl>().Damage(strength);

        }
        else
        {
            Debug.Log("No-Hit: Enemy");
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
        
        //Kills the enemy, damages the player
        if(transform.position.x <= -9.5f)
        {
            FindAnyObjectByType<PlayerController>().Damage(strength);
            Death();
        }

        if(target == null)
        {
            isAttacking = false;
        }

    }

    //need a coroutine for attacking interval
    private IEnumerator attackCycle()
    {
        while(true)
        {
            if(isAttacking)
            {
                Attack();
                yield return new WaitForSeconds(attackSpeed);
            }
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7)
        {
            isAttacking = true;
            Debug.Log("Found Tower");
            target = collision.collider;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isAttacking = false;
    }
   

}



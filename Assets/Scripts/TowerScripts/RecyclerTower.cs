using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecyclerTower : TowerControl
{
    private bool isAttacking = false;
    private List <GameObject> Enemies;
    public Animator animator;
    public ParticleSystem shredParticles;



    // Start is called before the first frame update
    void Start()
    {
        SetSpeed(0.5f); //faster attack speed
        SetHealth(50);
        SetDamage(20);
        StartCoroutine(AttackCycle());

        Enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        //May not be necessary but check anyways
        if(collision.gameObject.layer == 6)
        {
            isAttacking = true;
            //Debug.Log("Lets goooo");
            Enemies.Add(collision.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(Enemies.Contains(collision.gameObject))
        {
            Enemies.Remove(collision.gameObject);
        }
        if(Enemies.Count == 0)
        {
            isAttacking = false;
        }
    }

    public override void Attack()
    {
        Enemies.RemoveAll(enemy => enemy == null);
        for(int i = 0; i < Enemies.Count; i++)
        {
            GameObject obj = Enemies[i];

            Enemy enemy = obj.GetComponent<Enemy>();

            enemy.Damage(GetDamage());

            //if micro plastic enemy, damage twice
            if(enemy.GetComponent<MicroPlasticsEnemy>() != null)
            {
                enemy.Damage(GetDamage());
            }
            animator.Play("Shred");
            shredParticles.Play();
        }

    }

    private IEnumerator AttackCycle() 
    {
        while (true) {
            if(isAttacking)
            {
                yield return new WaitForSeconds(GetSpeed());
                Attack();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

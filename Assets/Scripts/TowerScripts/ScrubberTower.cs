using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class ScrubberTower : TowerControl
{
    //where to keep the smogs
    private Transform pos;

    //smogs in the thing
    private List<SmogEnemy> smogs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackCycle());

        smogs = new List<SmogEnemy>();
    }

    private IEnumerator AttackCycle()
    {
        while(true)
        {
            Attack();
            yield return new WaitForSeconds(GetSpeed());
        }

        
    }

    public override void Attack()
    {
        //Debug.Log("Attacking");
        RaycastHit[] hits;
        int hitMask = 1 << 6;
        hits = Physics.RaycastAll(transform.position + Vector3.left, transform.right, 2.0f, hitMask);
        
        Debug.DrawRay(transform.position + Vector3.left, Vector3.right);


        for (int i = 0; i < hits.Length; i++) {
            
            RaycastHit hit = hits[i];
            GameObject target = hit.collider.gameObject;
            //if (target == null) continue;
            Enemy enemy = target.GetComponent<Enemy>();

            if(enemy != null)
            {
                //Debug.Log("Hit something??");
                enemy.Damage(GetDamage());
            }
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hold them at this location, until this tower dies
        for(int i = 0; i < smogs.Count; i++)
        {
            if(smogs[i] == null)
            {
                smogs.Remove(smogs[i]);
                continue;
            }
            smogs[i].transform.position = pos.position;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with a thing!");
        if(collision.gameObject.GetComponent<SmogEnemy>() != null)
        {
            smogs.Add(collision.gameObject.GetComponent<SmogEnemy>());
            if(pos == null)
            {
                pos = collision.transform;
            }
        }

    }




}

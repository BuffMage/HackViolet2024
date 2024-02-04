using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ToxicBarrelEnemy : Enemy
{

    DebuffManager debuffer;

    [SerializeField] private float debuffTime;

    // Start is called before the first frame update
    void Start()
    {
        debuffer = FindObjectOfType<DebuffManager>();
        health = 150;
        speed = 1f;
        attackSpeed = 1f;
        strength = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.right, Vector3.left, out hit, 10f, hitMask)) {
            // Will do more stuff later
            Debug.Log("Did-Hit: Enemy");


            hit.transform.gameObject.GetComponent<TowerControl>().Damage(strength);

            //Apply/refresh the debuff
            debuffer.ApplyDebuff(hit.transform.gameObject, debuffTime);

        }
        else
        {
            Debug.Log("No-Hit: Enemy");
        }

    }



    
}

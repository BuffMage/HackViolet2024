using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class SmogEnemy : Enemy
{

    private bool isPhasing = false;
    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        speed = 1.5f;
        attackSpeed = 1f;
        strength = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Phase()
    {

        this.transform.position += Vector3.left * Time.deltaTime * speed/3.0f;
    }


    //Override fixed update so that it slowly passes through 

    void FixedUpdate()
    {
      
         if(!isAttacking && !isPhasing)
        {
            
            Move();
        }
        Phase();
        

    }   

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 7)
        {
            Debug.Log("Les goo");
            isAttacking = true;
        }
        isPhasing = true;

    }

    void OnTriggerExit(Collider collider)
    {
        isPhasing = false;

        if(isAttacking) isAttacking = false;
    }

}

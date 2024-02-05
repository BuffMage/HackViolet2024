using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmogEnemy : Enemy
{

    private List<Collider> currentColliders;

    private bool isPhasing = false;
    // Start is called before the first frame update
    void Start()
    {
        currentColliders = new List<Collider>();
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
        isPhasing = false;
        isAttacking = false;
        currentColliders.RemoveAll(col => {
            return col == null;
        });
        foreach(Collider col in currentColliders)
        {
            if (col.gameObject.layer == 7)
            {
                //Debug.Log("Les goo");
                isAttacking = true;
                isPhasing = true;
            }
        }

        //Kills the enemy, damages the player
        if(transform.position.x <= -9.5f)
        {
            FindAnyObjectByType<PlayerController>().Damage(strength);
            Death();
        }

        if(!isAttacking && !isPhasing)
        {
            
            Move();
            return;
        }
        Phase();
        

    }   

    void OnTriggerEnter(Collider collider)
    {
        currentColliders.Add(collider);
/*         if(collider.gameObject.layer == 7)
        {
            Debug.Log("Les goo");
            isAttacking = true;
            isPhasing = true;
        } */


    }

    void OnTriggerExit(Collider collider)
    {
        currentColliders.Remove(collider);
/*         if(collider.gameObject.layer == 7)
        {
            isPhasing = false;

            if(isAttacking) isAttacking = false;
        } */
    }
    

}

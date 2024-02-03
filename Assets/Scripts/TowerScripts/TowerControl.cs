using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    private int cost;
    private int damage;
    private GameObject model;
    private Rigidbody rb;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack() {
        
    }

    void Death() {
        Destroy(this.gameObject);
    }
}

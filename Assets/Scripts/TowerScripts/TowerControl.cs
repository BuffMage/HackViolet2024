using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    private int cost;
    private int damage;
    public GameObject model;
    private Rigidbody rb;
    private int health;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Attack() {

    }

    void Death() {
        Destroy(this.gameObject);
    }

    public int GetDamage() {
        return damage;
    }

    public void SetDamage(int damage) {
        this.damage = damage;
    }

    public float GetSpeed() {
        return speed;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void Damage(int amount) {
        health -= amount;

        if (health <= 0) {
            Death();
        }
    }
}

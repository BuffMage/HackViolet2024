using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] protected int cost = 100;
    [SerializeField] private int damage;
    public GameObject model;
    private Rigidbody rb;
    [SerializeField] private int health;
    [SerializeField] private float speed;

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

    public int GetHealth()
    {
        return health;
    }

    //Only used for initialization purposes sonnnn
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetCost() {
        return cost;
    }

    public void SetCost(int cost) {
        this.cost = cost;
    }

    public void Damage(int amount) {
        health -= amount;

        if (health <= 0) {
            Death();
        }
    }
}

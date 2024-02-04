using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class WindTurbine : TowerControl
{
    [SerializeField] private int cooldown = 10;
    private bool canCooldown = true;
    [SerializeField] private float push = 50;

    // Start is called before the first frame update
    void Start()
    {
        SetDamage(50);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canCooldown) {
            PushEnemyBack();
        }
    }

    public void PushEnemyBack() {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.right, 100.0F);
        canCooldown = false;

        for (int i = 0; i < hits.Length; i++) {
            RaycastHit hit = hits[i];
            GameObject target = hit.transform.gameObject;
            Enemy enemy = target.GetComponent<Enemy>();

            Transform t = enemy.GetComponent<Transform>();
            Rigidbody rb = enemy.GetComponent<Rigidbody>();

            // rb.AddForce(Vector3.right * push);
            // t.position = Vector3.Lerp(t.position, t.position + Vector3.right * push, Time.time/20);
            rb.MovePosition((rb.transform.position + Vector3.right * push) * Time.deltaTime * push);

            SmogEnemy smog = target.GetComponent<SmogEnemy>();
            if (smog != null) {
                smog.Damage(GetDamage());
            }
        }
    }

    public override void Attack() {
        // add money to system
    }

    private IEnumerator AttackCycle() {
        while (true) {
            Attack();
            yield return new WaitForSeconds(GetSpeed());
        }
    }

    private IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldown);
        canCooldown = true;
    }
}

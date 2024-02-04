using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarTower : TowerControl
{
    public CanvasGroup laserGroup;

    // Start is called before the first frame update
    void Start()
    {
        SetSpeed(3);
        SetDamage(12);
        SetHealth(20);
        StartCoroutine(AttackCycle());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    public override void Attack() {
        RaycastHit hit;
        int hitMask = 1 << 6;
        Debug.DrawRay(transform.position, Vector3.right, Color.red, 5f);
        if (Physics.Raycast(transform.position, Vector3.right, out hit, Mathf.Infinity, hitMask)) {
            // Will do more stuff later
            Debug.Log("Did-Hit");
            GameObject target = hit.transform.gameObject;

            Enemy enemy = target.GetComponent<Enemy>();

            enemy.Damage(GetDamage());
            var seq = LeanTween.sequence();
            seq.append(laserGroup.LeanAlpha(1f, .2f));
            seq.append(laserGroup.LeanAlpha(0f, .2f));
        }
    }

    private IEnumerator AttackCycle() {
        while (true) {
            yield return new WaitForSeconds(GetSpeed());
            Attack();
        }
    }
}

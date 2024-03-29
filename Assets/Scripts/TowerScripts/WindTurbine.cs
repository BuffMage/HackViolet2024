using System.Collections;
using UnityEngine;

public class WindTurbine : TowerControl
{
    [SerializeField] private int cooldown = 5;
    private bool canCooldown = true;
    [SerializeField] private float push = 50;

    public ParticleSystem pushBackEffect;

    // Start is called before the first frame update
    void Awake()
    {
        SetDamage(50);
        SetSpeed(10);
        SetCost(100);
    }

    void Start()
    {
        StartCoroutine(AttackCycle());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canCooldown) {
            PushEnemyBack();
        }
    }

    public void PushEnemyBack() 
    {
        pushBackEffect.Play();
        Invoke(nameof(StopParticles), 3f);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.right, 100.0F, 1 << 6);
        Debug.DrawRay(transform.position, transform.right, Color.red, 3f);
        canCooldown = false;
        StartCoroutine(Cooldown());

        for (int i = 0; i < hits.Length; i++) {
            RaycastHit hit = hits[i];
            GameObject target = hit.collider.gameObject;
            //if (target == null) continue;
            Enemy enemy = target.GetComponent<Enemy>();

            Transform t = enemy.GetComponent<Transform>();
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            enemy.PushBack(3f);
            //Debug.Log("Really tryin here :(");

            // rb.AddForce(Vector3.right * push);
            // t.position = Vector3.Lerp(t.position, t.position + Vector3.right * push, Time.time/20);
            //rb.MovePosition((rb.transform.position + Vector3.right * push) * Time.deltaTime * push);

            SmogEnemy smog = target.GetComponent<SmogEnemy>();
            if (smog != null) {
                smog.Damage(GetDamage());
            }
        }
    }

    public void StopParticles()
    {
        pushBackEffect.Stop();
    }

    public override void Attack() 
    {
        ItemPlacement.Instance.ChangeMoney(25);
    }

    private IEnumerator AttackCycle() 
    {
        while (true) {
            yield return new WaitForSeconds(GetSpeed());
            Attack();
        }
    }

    private IEnumerator Cooldown() 
    {
        yield return new WaitForSeconds(cooldown);
        canCooldown = true;
    }
}

using UnityEngine;
using System.Collections;

public class NavScriptArrive : MonoBehaviour {

    public Transform target;
    public NavMeshAgent agent;

    private bool startAttack = false;
    private float fireRate;
    private EnemyHealth enemyHealth;
    private Animation anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponentInChildren<EnemyHealth>();
        anim = GetComponentInChildren<Animation>();
        if (gameObject.tag == "Melee")
        {
            target.position = new Vector3(6.5f, 1f, Random.Range(-3.3f, -31f));
            fireRate = 4f;
        }
        if (gameObject.tag == "Range")
        {
            target.position = new Vector3(2f, 1f, Random.Range(-3.3f, -31f));
            fireRate = 2.5f;
        }
        if (gameObject.tag == "Boss")
        {
            target.position = new Vector3(-8.5f, 2f, Random.Range(-3.3f, -31f));
            fireRate = 8f;
        }
        agent.SetDestination(target.position);
    }

    void Update()
    {
        if (agent.remainingDistance <= 0.01f)
        {
            if (!startAttack)
            {
                startAttack = true;
                anim.Play("Idle");
                StartCoroutine(Attack(fireRate));
            }
        }
    }

    public float GetRemainingDistance()
    {
        return agent.remainingDistance;
    }

    private IEnumerator Attack(float fireRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if (!enemyHealth.GetDead())
                anim.Play("Attack1");
            if (gameObject.tag == "Melee")
                GameData._Instance.Health -= 2;
            if (gameObject.tag == "Range")
                GameData._Instance.Health -= 4;
            if (gameObject.tag == "Boss")
                GameData._Instance.Health -= 9;
            if (GameData._Instance.Health <= 0)
                break;
        }
    }
}

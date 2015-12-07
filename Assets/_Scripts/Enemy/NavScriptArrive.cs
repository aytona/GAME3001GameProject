using UnityEngine;
using System.Collections;

public class NavScriptArrive : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Whatever object having type NavMeshAgent; agent is an array contains all NavMeshAgent
        target.position = new Vector3(6.5f, 1f, Random.Range(-3.3f, -31f));
        agent.SetDestination(target.position);
    }
}

using UnityEngine;
using UnityEngine.AI;

public class enemynavigation : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}

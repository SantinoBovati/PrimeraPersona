using UnityEngine;
using UnityEngine.AI;

public class enemynavigation : MonoBehaviour
{

    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

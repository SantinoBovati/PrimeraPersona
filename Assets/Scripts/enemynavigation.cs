using UnityEngine;
using UnityEngine.AI;

public class enemynavigation : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform target;

    public Animator EnemyAnimator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        if (agent.velocity.magnitude > 0)
        {
            EnemyAnimator.SetBool("isMoving", true);
        }
        else
        {
            EnemyAnimator.SetBool("isMoving", false);
        }
    }

    private void UpdateTarget()
    {
        agent.destination = target.position;

        if (agent.speed > 0)
        {
            EnemyAnimator.SetBool("isMoving", true);
        }
        else
        {
            EnemyAnimator.SetBool("isMoving", false);
        }
    }
}

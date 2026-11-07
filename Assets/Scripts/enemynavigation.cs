using UnityEngine;
using UnityEngine.AI;

public class enemynavigation : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform target;

    public Animator EnemyAnimator;

    public bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyAnimator = GetComponentInChildren<Animator>();

        InvokeRepeating("UpdateTarget", 3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            return;
        }

        bool isMoving = agent.velocity.magnitude > 0.1f && !agent.isStopped;

        if (isMoving)
        {
            EnemyAnimator.SetBool("IsMoving", true);
        }
        else
        {
            EnemyAnimator.SetBool("IsMoving", false);
        }
    }

    private void UpdateTarget()
    {
        agent.destination = target.position;
    }

    public void die()
    {
        EnemyAnimator.SetTrigger("die");
        agent.isStopped = true;
    }
}

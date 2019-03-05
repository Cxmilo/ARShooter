using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Walking,
    Attacking,
    Die
}

public class EnemyBase : MonoBehaviour
{
    public Transform tower;
    private Animator animator;
    private NavMeshAgent navMeshComponent;

    public float damage;
    public float life;
    public float attackRange;
    public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshComponent = GetComponent<NavMeshAgent>();

        if (tower)
        {
            navMeshComponent.SetDestination(tower.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { SetState(EnemyState.Idle); }
        if (Input.GetKeyDown(KeyCode.S)) { SetState(EnemyState.Walking); }

        switch (currentState)
        {
            case EnemyState.Idle:
                IdleState();
                break;
            case EnemyState.Walking:
                Walking();
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Die:
                break;
            default:
                break;
        }
    }

    public void SetState(EnemyState nextState)
    {
        currentState = nextState;
        switch (currentState)
        {
            case EnemyState.Idle:
                animator.SetTrigger("Idle");

                break;
            case EnemyState.Walking:
                animator.SetTrigger("StartWalk");
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Die:
                break;
            default:
                break;
        }
    }

    public void IdleState()
    {
        navMeshComponent.velocity = Vector3.zero;
    }
    public void Walking()
    {
        if (tower)
        {
            navMeshComponent.SetDestination(tower.position);
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float chaseSpeed;

    public float stopChasingDistance;
    public float attackingDistance;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (SoundManager.Instance.zombieChannel1.isPlaying == false)
        {
            SoundManager.Instance.zombieChannel1.PlayOneShot(SoundManager.Instance.zombieChase);

        }
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer= Vector3.Distance(player.position,animator.transform.position);
        if(distanceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("isChasing", false);
        }

        if(distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
        SoundManager.Instance.zombieChannel1.Stop();
    }
}

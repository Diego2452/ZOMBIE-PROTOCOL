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

        // Get the direction vector from the zombie to the player
        Vector3 direction = (player.position - animator.transform.position).normalized;

        // Calculate the rotation to look towards the player
        Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Smoothly rotate the zombie towards the player
        float rotationSpeed = 5f; // Adjust the speed as needed
        float rotationFactor = rotationSpeed * Time.deltaTime;
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRotation, rotationFactor);

        agent.SetDestination(player.position);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("isChasing", false);
        }

        if (distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("isAttacking", true);
        }
    }
    

    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (SoundManager.Instance.zombieChannel1.isPlaying == false)
    //    {
    //        SoundManager.Instance.zombieChannel1.PlayOneShot(SoundManager.Instance.zombieChase);

    //    }
    //    agent.SetDestination(player.position);
    //    animator.transform.LookAt(player);

    //    float distanceFromPlayer= Vector3.Distance(player.position,animator.transform.position);
    //    if(distanceFromPlayer > stopChasingDistance)
    //    {
    //        animator.SetBool("isChasing", false);
    //    }

    //    if(distanceFromPlayer < attackingDistance)
    //    {
    //        animator.SetBool("isAttacking", true);
    //    }
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
        SoundManager.Instance.zombieChannel1.Stop();
    }
}

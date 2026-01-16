using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public int damageAmount = 2; 
    public float damageInterval = 3f; 
    private float timer = 0f;

    public float stopAttackingDistance;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        InflictDamageToPlayer();
        timer = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (SoundManager.Instance.zombieChannel1.isPlaying == false)
        {
            SoundManager.Instance.zombieChannel1.PlayOneShot(SoundManager.Instance.zombieAttack);
        }
        LookAtPlayer();
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
        }

        timer += Time.deltaTime;

        if (timer >= damageInterval)
        {
            InflictDamageToPlayer();
            timer = 0f;
        }
    }

    private void InflictDamageToPlayer()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TakeDamage(damageAmount);
    }

    private void LookAtPlayer()
    {
        Vector3 direction =player.position-agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation=Quaternion.Euler(0,yRotation, 0);
    }
    public override  void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        SoundManager.Instance.zombieChannel1.Stop();
    }

}

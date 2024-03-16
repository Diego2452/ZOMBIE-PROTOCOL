using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float vida;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }
}

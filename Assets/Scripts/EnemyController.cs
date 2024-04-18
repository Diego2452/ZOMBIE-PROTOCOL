using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int Vida;
    private Animator animator;

    private NavMeshAgent agent;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            int RandomNumber = Random.Range(0, 2);
            if (RandomNumber == 0)
            {
                animator.SetTrigger("DIE1");
              
            }
            else
            {
                animator.SetTrigger("DIE2");
            }
            isDead = true;
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieDeath);
            agent.isStopped = true;

        }
        else
        {
            animator.SetTrigger("DAMAGE");
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieHurt);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);//Attack and Stop Attacking
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,15f);// Detection (start Chasing)
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 20f);// Stop Chasing
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int Vida;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Vida -= damage;
        if(Vida <= 0) 
        {
            int RandomNumber=Random.Range(0,2);
            if(RandomNumber==0 )
            {
                animator.SetTrigger("DIE1");
                Destroy(gameObject);
            }
            else
            {
                animator.SetTrigger("DIE2");
                Destroy(gameObject);

            }
        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }

    
}

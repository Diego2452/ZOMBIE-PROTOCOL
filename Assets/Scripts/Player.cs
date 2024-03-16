using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int Vida;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            print("Player Dead");
        }
        else
        {
            print("Player Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
        }
    }
}

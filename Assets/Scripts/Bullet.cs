using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public int bulletDamage;
    private void OnCollisionEnter(Collision objectWeHit)
    {
        if (objectWeHit.gameObject.CompareTag("Target"))
        {
            print("hit " + objectWeHit.gameObject.name + " !");

            CreateBulletImpactEffect(objectWeHit);

            Destroy(gameObject);
        }

        if (objectWeHit.gameObject.CompareTag("Wall"))
        {
            print("hit a wall");

            CreateBulletImpactEffect(objectWeHit);

            Destroy(gameObject);
        }

        if (objectWeHit.gameObject.CompareTag("Beer"))
        {
            print("hit a beer bottle");
            objectWeHit.gameObject.GetComponent<BeerBottle>().Shatter();

            // We will not destroy the bullet on impact, it will get destroyed according to its lifetime
        }

        if (objectWeHit.gameObject.CompareTag("Zombie"))
        {
            print("hit a zombie");
            if (objectWeHit.gameObject.GetComponent<EnemyController>().isDead == false)
            {
                objectWeHit.gameObject.GetComponent<EnemyController>().TakeDamage(10);
            }
            
            CreateBloodSprayEffect(objectWeHit);
            Destroy(gameObject);
        }
    }

    private void CreateBloodSprayEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject bloodSprayPrefab = Instantiate(
            GlobalReferences.Instance.bloodSprayEffect,
            contact.point,
            Quaternion.LookRotation(contact.normal));

        bloodSprayPrefab.transform.SetParent(objectWeHit.gameObject.transform);
        Destroy(bloodSprayPrefab, 0.5f);
    }

    void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );

        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource ShootingChannel;

    public AudioClip m1911_fp;
    public AudioClip m4a1_fp;
    public AudioClip ksg_fp;

    public AudioSource reloadingSoundM1911;
    public AudioSource reloadingSoundM4a1;
    public AudioSource reloadingSoundKSG;

    public AudioSource emptyMagazineSoundM1911;

    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;

    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    public AudioSource zombieChannel1;
    public AudioSource zombieChannel2;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon) 
        {
            case WeaponModel.M1911:
                ShootingChannel.PlayOneShot(m1911_fp); 
                break;
            case WeaponModel.M4a1:
                ShootingChannel.PlayOneShot(m4a1_fp);
                break;
            case WeaponModel.KSG:
                ShootingChannel.PlayOneShot(ksg_fp);
                break;
        }
    }
    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.M1911:
                reloadingSoundM1911.Play();
                break;
            case WeaponModel.M4a1:
                reloadingSoundM4a1.Play();
                break;
            case WeaponModel.KSG:
                reloadingSoundM4a1.Play();
                break;
        }
    }
}

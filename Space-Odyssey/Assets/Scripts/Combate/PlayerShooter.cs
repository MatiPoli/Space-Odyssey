using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerCombat
{
    public Transform bulletOrigin;
    public ParticleSystem muzzleFlash;

    AudioSource sonidoDisparo;

    void Start()
    {
        sonidoDisparo = GetComponent<AudioSource>();
    }

    void playSonidoDisparo()
    {
        sonidoDisparo.PlayOneShot(sonidoDisparo.clip);
    }

    override protected void attack()
    {
        // Animacion de disparo
        
        // Flash
        muzzleFlash.Play();

        // Sonido de disparo
        playSonidoDisparo();

        //Deteccion de golpe
        RaycastHit hit;
        if(Physics.Raycast(bulletOrigin.transform.position, bulletOrigin.transform.forward,out hit,attackRange))
        {
            DamageTarget target = hit.transform.GetComponent<DamageTarget>();

            if (target != null)
                target.recibirDanio(attackDamage);
        }
    }
}


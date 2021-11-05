using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Arma
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

    override public void attack()
    {
        if (!attackReady())
            return;

        // Animacion de disparo

        // Flash
        muzzleFlash.Play();

        // Sonido de disparo
        playSonidoDisparo();

        //Deteccion de golpe
        RaycastHit hit;
        if (Physics.Raycast(bulletOrigin.transform.position, bulletOrigin.transform.forward, out hit, attackRange))
        {
            //Debug.Log("Le pegue un balaso a " + hit.transform.gameObject.name);
            DamageTarget target = hit.transform.GetComponent<DamageTarget>();

            if (target != null)
                target.recibirDanio(attackDamage);
        }
    }
}
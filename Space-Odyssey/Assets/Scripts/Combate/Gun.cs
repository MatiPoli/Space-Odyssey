using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Arma
{
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

        Ray ray = new Ray(attackOrigin.position, attackOrigin.forward);

        Debug.DrawRay(ray.origin, ray.direction * attackRange);

        //Deteccion de golpe
        RaycastHit hit;


        if (Physics.Raycast(attackOrigin.transform.position, attackOrigin.transform.forward, out hit, attackRange))
        {
            //Debug.Log("Le pegue un balaso a " + hit.transform.gameObject.name);
            DamageTarget target = hit.transform.GetComponent<DamageTarget>();

            if (target != null)
                target.recibirDanio(attackDamage);
        }
    }
}
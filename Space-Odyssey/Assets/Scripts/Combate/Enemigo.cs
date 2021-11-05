using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemigo : DamageTarget
{
    public Animator animator;
    AudioSource death_sound;

    new void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        death_sound = GetComponent<AudioSource>();
    }

    public override void recibirDanio(float danio)
    {
        if (vida > 0)
        {
            base.recibirDanio(danio);
            // Animacion de daño
            animator.SetTrigger("Lastimado");
        }
    }

    protected override void die()
    {
        // Animacion de Muerte
        animator.SetBool("Lo Nismearon", true);

        // Sonido de muerte
        if(death_sound != null)
            death_sound.PlayOneShot(death_sound.clip);
    }
}

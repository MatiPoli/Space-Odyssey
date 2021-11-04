using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerCombat
{
    public Transform bulletOrigin;
    public ParticleSystem muzzleFlash;

    override protected void attack()
    {
        // Animacion de disparo
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(bulletOrigin.transform.position, bulletOrigin.transform.forward,out hit,attackRange))
        {
            DamageTarget target = hit.transform.GetComponent<DamageTarget>();

            if (target != null)
                target.recibirDanio(attackDamage);
        }
    }
}


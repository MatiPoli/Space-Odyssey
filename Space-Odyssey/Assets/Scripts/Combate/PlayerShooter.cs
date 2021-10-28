using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : PlayerCombat
{
    public Camera cam;
    public Transform bulletOrigin;

    // Start is called before the first frame update
    override protected void attack()
    {
        // Animacion de disparo

        RaycastHit hit;
        if(Physics.Raycast(bulletOrigin.transform.position, bulletOrigin.transform.forward,out hit,attackRange))
        {
            Debug.Log("Le pegue un balaso a " + hit.transform.name);

            DamageTarget target = hit.transform.GetComponent<DamageTarget>();

            if (target != null)
                target.recibirDanio(attackDamage);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : PlayerCombat
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    override protected void attack()
    {
        if (attackPoint == null)
            return;
        Collider[] enemigos = Physics.OverlapSphere(attackPoint.position,attackRange,enemyLayers);
        foreach (Collider enemigo in enemigos)
        {
            Enemigo enemy = enemigo.GetComponent<Enemigo>();
            Debug.Log("Le pegue un piñon a " + enemy.name);
            enemy.recibirDanio(attackDamage);
        }
    }
}

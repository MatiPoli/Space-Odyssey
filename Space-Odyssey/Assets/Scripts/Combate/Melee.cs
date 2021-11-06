using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Arma
{
    [Header("Arma")]
    public Transform attackPoint;
    public LayerMask enemyLayers;

    override public void attack()
    {
        if (!attackReady())
            return;

        // Animacion de ataque

        //Deteccion de golpe
        Collider[] enemigos = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemigo in enemigos)
        {
            DamageTarget enemy = enemigo.GetComponent<DamageTarget>();
            Debug.Log("Le pegue un piñon a " + enemigo.name);
            enemy.recibirDanio(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 25;
    public float attackRate = 1f;
    public Transform attackOrigin;
    float nextAttackTime = 0;

    protected bool attackReady()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            return true;
        }
        return false;
    }

    abstract public void attack();
}

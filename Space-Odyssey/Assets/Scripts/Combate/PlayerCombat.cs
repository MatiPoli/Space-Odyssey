using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombat : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 25;
    public float attackRate = 1f;
    float nextAttackTime = 0;

    // Update is called once per frame
    virtual protected void Update()
    {
        if (Time.time >= nextAttackTime && Input.GetMouseButtonDown(0))
        {
            attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    abstract protected void attack();
}

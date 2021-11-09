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

    protected void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = true;
        }
    }

    protected bool attackReady()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            return true;
        }
        return false;
    }

    public void dropWeapon()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb)
        {
            Gravedad gravityScript = GetComponent<Gravedad>();
            if (gravityScript)
            {
                gravityScript.enabled = true;
                //rb.constraints = RigidbodyConstraints.None;
                rb.isKinematic = false;
            }
            else
                rb.useGravity = true;
        }
        this.enabled = false;
    }

    abstract public void attack();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Enemigo : DamageTarget
{
    Animator animator;
    AudioSource death_sound;
    NavMeshAgent agent;

    [Header("Arma")]
    public Arma arma;

    [Header("Datos del enemigo a vencer")]
    public LayerMask targetLayer;
    public Transform target;

    void Awake()
    {
        animator = GetComponent<Animator>();
        death_sound = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        bool targetEnRango = Physics.CheckSphere(transform.position, arma.attackRange, targetLayer);
        if (targetEnRango)
        {
            agent.SetDestination(transform.position);
            faceTarget();
            arma.attack();
        }
        else
            agent.SetDestination(target.position);

    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
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

        agent.enabled = false;
        this.enabled = false;

    }
}

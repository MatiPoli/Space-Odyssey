using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Enemigo : DamageTarget
{
    Rigidbody rb;
    Animator animator;
    AudioSource death_sound;
    NavMeshAgent agent;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;


    [Header("Movimiento")]
    public float velocidad;

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
        rb = GetComponent<Rigidbody>();
        //target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        bool targetEnRango = Physics.CheckSphere(transform.position, arma.attackRange, targetLayer);
        faceTarget();
        if (targetEnRango)
        {
            //agent.SetDestination(transform.position);
            mover(Vector3.zero);
            arma.attack();
        }
        else
        {
            mover(Vector3.forward);
        }
            //agent.SetDestination(target.position);

    }
    void mover(Vector3 direcson)
    {
        Vector3 targetMovementAmount = direcson * velocidad;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMovementAmount, ref smoothMoveVelocity, .15f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
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

        this.enabled = false;

    }
}

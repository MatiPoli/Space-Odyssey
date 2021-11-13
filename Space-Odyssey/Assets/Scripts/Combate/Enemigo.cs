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

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    Atractor atractorGameObject;

    [Header("Movimiento")]
    public float velocidad;

    [Header("Arma")]
    public Arma arma;

    [Header("Datos del enemigo a vencer")]
    public LayerMask targetLayer;
    public Transform target;

    [Header("IA")]
    public float rangoVision;

    void Awake()
    {
        animator = GetComponent<Animator>();
        death_sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        atractorGameObject = GetComponent<Gravedad>().atractor;
        //target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (targetEnRangoAtaque())
        {
            mover(Vector3.zero);
            faceTarget();
            //agent.SetDestination(transform.position);
            for (int i = 0; i < 100; i++)
                aimToTarget();
            // Animacion de ataque
            animator.SetBool("Atacando",true);
            arma.attack();
        }
        else 
        {   
            animator.SetBool("Atacando",false);
            if (targetOnSight())
            {
                faceTarget();
                mover(Vector3.forward);
            }
            else
                mover(Vector3.zero);
        }
    }
    bool targetEnRangoAtaque()
    {
        return (target.position - arma.attackOrigin.position).magnitude <= arma.attackRange;
    }

    bool targetOnSight()
    {
        return (target.position - arma.attackOrigin.position).magnitude <= rangoVision;
    }

    void mover(Vector3 direcson)
    {
        #region Animacion de caminata
            animator.SetBool("Caminando",(direcson!=Vector3.zero));
        #endregion
        Vector3 targetMovementAmount = direcson * velocidad;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMovementAmount, ref smoothMoveVelocity, .15f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void faceTo(Vector3 pos)
    {
        transform.LookAt(pos);
        if (atractorGameObject != null)
            atractorGameObject.rotate(this.gameObject);
    }

    void faceTarget()
    {
        faceTo(target.position);
    }

    void aimToTarget()
    {
        arma.attackOrigin.LookAt(target.position);
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

        // El enemigo suelta el arma al morir
        arma.dropWeapon();

        this.enabled = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(arma.attackOrigin.position, rangoVision);
    }

}

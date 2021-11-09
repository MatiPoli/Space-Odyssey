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
    public float esperaEntreMovimiento;

    float tiempoDesdeMovimiento = 0;

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
            faceTarget();
            //agent.SetDestination(transform.position);
            mover(Vector3.zero);
            for (int i = 0; i < 100; i++)
                aimToTarget();
            arma.attack();
        }
        else if (targetOnSight())
        {
            faceTarget();
            mover(Vector3.forward);
        }
        else
            mover(Vector3.zero);
    }
    bool targetEnRangoAtaque()
    {
        return (target.position - arma.attackOrigin.position).magnitude <= arma.attackRange;
    }

    bool targetOnSight()
    {
        return (target.position - arma.attackOrigin.position).magnitude <= rangoVision;
    }

    void wander()
    {
        tiempoDesdeMovimiento += Time.deltaTime;
        if (tiempoDesdeMovimiento < esperaEntreMovimiento)
        {
            //mover(Vector3.zero);
            return;
        }
        tiempoDesdeMovimiento = 0;
        Vector3[] directions = new Vector3[] { transform.forward, transform.right};
        int dir = Random.Range(-1, 1);
        int i = Random.Range(0, directions.Length-1);
        mover(dir * directions[i]);
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
        transform.LookAt(target.position);
        if (atractorGameObject != null)
            atractorGameObject.rotate(this.gameObject);
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

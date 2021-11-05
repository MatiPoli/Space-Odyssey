using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxVida = 100;
    protected float vida;

    protected void Start()
    {
        vida = maxVida;
    }

    public float getVida()
    {
        return this.vida;
    }

    public void subirVida(float valor) {

        vida = valor;

    }

    public virtual void recibirDanio(float danio)
    {
        vida -= danio;

        // Animacion de daño

        if (vida <= 0f)
            die();
    }

    // Update is called once per frame
    protected void Update()
    {
        //Debug.Log(vida);   
    }

    protected virtual void die()
    {
        //Destroy(this.gameObject);
    }
}

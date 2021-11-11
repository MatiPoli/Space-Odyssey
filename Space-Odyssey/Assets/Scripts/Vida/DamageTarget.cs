using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Vida")]
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

    public void RecuperarVida(float cantidad_a_restaurar){
        this.vida += cantidad_a_restaurar;
        actualizarVida(this.vida);
        print("Se ha recuperado " + cantidad_a_restaurar + " exitosamente");
    }

    public float getMaxVida()
    {
        return this.maxVida;
    }

    public void actualizarVida(float nuevaVida)
    {
        this.vida=nuevaVida;
    }
    public virtual void recibirDanio(float danio)
    {
        vida -= danio;

        // Animacion de daño

        if (vida <= 0f)
            die();
    }

    protected virtual void die()
    {
        //Destroy(this.gameObject);
    }
}

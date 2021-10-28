using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxVida = 100;
    protected int vida;

    void Start()
    {
        vida = maxVida;
    }

    public virtual void recibirDanio(int danio)
    {
        vida -= danio;

        // Animacion de daño

        if (vida <= 0)
            die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void die()
    {
        Destroy(this.gameObject);
    }
}

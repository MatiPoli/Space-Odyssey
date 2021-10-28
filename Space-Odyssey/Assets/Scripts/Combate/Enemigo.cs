using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : DamageTarget
{
    public override void recibirDanio(int danio)
    {
        base.recibirDanio(danio);
        // Animacion de daño
    }

    protected override void die()
    {
        Debug.Log(this.name + " ha muerto!");
        // Animacion de Muerte
        Destroy(this.gameObject);
    }
}

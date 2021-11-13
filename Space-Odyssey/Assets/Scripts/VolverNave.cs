using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverNave : MonoBehaviour
{
    [Header("Datos generales")]
    public float rangoEscape=10f;

    [Header("Datos jugador")]
    public LayerMask layerJugador;

    [Header("Teclas")]
    public KeyCode teclaEscape=KeyCode.F;

    // Update is called once per frame
    void Update()
    {
        if (playerEstaCerca() && Input.GetKey(teclaEscape))
            SceneManager.LoadScene("Scenes/Espacio");
    }

    bool playerEstaCerca()
    {
        return Physics.CheckSphere(this.transform.position, rangoEscape, layerJugador);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, rangoEscape);   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave_translate : MonoBehaviour
{
    public float velocidad_retroceso = 0.5f;
    public float velocidad_maxima = 5;
    public float velocidad_rotacion = 60;
    private float velocidad = 0;
    public float aceleracion = 0.5f;
    private float tiempo_movimiento;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "lowpoly_earth")
            SceneManager.LoadScene("Scenes/Juego");
    }

    void acelerar()
    {
        velocidad = Mathf.Min(aceleracion*(tiempo_movimiento%60),velocidad_maxima);
        tiempo_movimiento += Time.deltaTime;
    }
    
    void desacelerar()
    {
        tiempo_movimiento = Mathf.Min(tiempo_movimiento, (velocidad / aceleracion));
        velocidad = Mathf.Max(aceleracion*(tiempo_movimiento%60), 0f);
        tiempo_movimiento = Mathf.Max(0f, tiempo_movimiento - Time.deltaTime);
    }

    void mover()
    {
        if (Input.GetKey(KeyCode.W))
            acelerar();
        else
            desacelerar();

        transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));

        if (Input.GetKey(KeyCode.S))
        {
            if (velocidad > 0)
                desacelerar();
            else
                transform.Translate(new Vector3(0, 0, -velocidad_retroceso * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, -velocidad_rotacion * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, velocidad_rotacion * Time.deltaTime, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(velocidad);
        mover();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Transform jugador;
    public float velocidad;
    bool estarAlerta;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta == true)
        {
            //transform.LookAt(jugador);
            transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime);
        }
    }
    public void OnDrawGizmo()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}


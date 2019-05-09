using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movglobes : MonoBehaviour
{
    public float velocidad;
    public float distancia;
    private float contador;
    private float posInici;
    void Start()
    {
        posInici = transform.position.x;
    }

    
    void Update()
    {
        contador += Time.deltaTime * velocidad;
        transform.position = new Vector2(Mathf.PingPong(contador,distancia) + posInici, transform.position.y);

    }
}

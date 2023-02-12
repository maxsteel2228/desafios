using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationspeed;
    [SerializeField] private Transform maxtel;
    [SerializeField] private Transform mirar;
    [SerializeField] private float pursuitdistance;
    [SerializeField] private float timer;
    [SerializeField] private float tiempo;
    public float health;
    [SerializeField] private float startfllowing;
    [SerializeField] private float damage;
    [SerializeField] private dificulty estado;
    [SerializeField] private float maxhealht;
    
    public enum dificulty
    {
        facil,
        dificil,
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        follow();
        watch();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        EljodidoSwithc();
    }

    private void watch()
    {
        
        var vectormax = maxtel.position - transform.position;
        var newrotation = Quaternion.LookRotation(vectormax);
        transform.rotation = Quaternion.Lerp(a: transform.rotation, b: newrotation, t: Time.deltaTime * rotationspeed);
    }

    private void follow()
    {
        var vectormax = maxtel.position - transform.position;
        var distance = vectormax.magnitude;
        if(distance > pursuitdistance && distance < startfllowing)
        {
            
            transform.position += vectormax.normalized * (speed * Time.deltaTime);
            
        }
       
        
    }

    private void OnCollisionStay(Collision collision)
    {
        var dam = collision.gameObject.GetComponent<maxtel>();
        if (timer <= Time.time && dam)
        {
            timer = Time.time + tiempo;
            dam.dañoenemigo(damage);
        }
       

    }

    public void TePego(float daño)
    {
        health -= damage;
    }

    private void Desaparecer()
    {
        Destroy(gameObject);
    
    }

    private void masjodido()
    {
        
    }

    private void EljodidoSwithc()
    { 
        switch(estado)
        {
            case dificulty.facil:
                Desaparecer();
                break;
            case dificulty.dificil:
                masjodido();
                break;
        }
    
    }
}

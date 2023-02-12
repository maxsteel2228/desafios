using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemigopro : MonoBehaviour
{
    [SerializeField] private Transform maxtel;
    [SerializeField] private float pursuitdistance;
    [SerializeField] private float startfllowing;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timer;
    [SerializeField] private float tiempo;
    [SerializeField] private float health;
    [SerializeField] private float rotationspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        follow();
        watch();
        
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
        if (distance > pursuitdistance && distance < startfllowing)
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
            dam.dañogrande(damage);
        }


    }
    public void tePegoGrande(float muchoDaño)
    {
        health -= damage;

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class maxtel : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody jump;
    [SerializeField] private float jumplvl;
    [SerializeField] private float tim;
    [SerializeField] private float timer;
    [SerializeField] private float damagetotake;
    [SerializeField] private float damageEnemy;
    [SerializeField] private float tim2;
    [SerializeField] private float timer2;
    [SerializeField] private Transform enemigo;
    [SerializeField] private Transform enemigopro;
    [SerializeField] private float dañoEnorme;
    [SerializeField] private float curacion;
    [SerializeField] private float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var verticalaxis = Input.GetAxisRaw("Vertical");
        Move(verticalaxis);
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5, 0);
            
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 5, 0);
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && timer <= Time.time)
        {
            timer = Time.time + tim;
            jump.AddForce(Vector3.up * jumplvl);
        }

        dead();
        curacionportimepo();
        
    }

    private void Move(float vAxis)
    {
        transform.position += transform.right * vAxis * (speed * Time.deltaTime);
        
    }

    private void dead()
    {
        if(health <= 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);
        }
    }

    public void dama(float da)
    {
        health -= damagetotake;
    }


    public void dañoenemigo(float nose)
    {
        health -= damageEnemy;
    }

    public void dañogrande(float gigante)
    {
        health -= dañoEnorme;
    }

    private void OnCollisionStay(Collision collision)
    {
        var dam = collision.gameObject.GetComponent<enemigo>();
        var giga = collision.gameObject.GetComponent<enemigopro>();
        

     
        
            if (Input.GetKeyDown(KeyCode.F) && timer2 < Time.time)
            {
                timer2 = Time.time + tim2;
                dam.TePego(damage);
            

            }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && timer2 < Time.time)
            {
                timer2 = Time.time + tim2;
                giga.tePegoGrande(damage);
                

            }
        }





    }

    private void curacionportimepo()
    {
        
        if(health < maxhealth)
        {
            health += curacion;
        }
    }
    
}

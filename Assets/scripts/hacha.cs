using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacha : MonoBehaviour
{
    [SerializeField] private float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        var da�o = other.GetComponent<maxtel>();
        if(da�o != null)
        {
            da�o.dama(damage);
        }

    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camara1;
    [SerializeField] private CinemachineVirtualCamera camara2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            turncamara(camara1, camara2);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            turncamara(camara2, camara1);
        }
        
    }

    private void turncamara(CinemachineVirtualCamera cam1, CinemachineVirtualCamera cam2)
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
    }
}

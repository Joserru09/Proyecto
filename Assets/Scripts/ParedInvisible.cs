using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInvisible : MonoBehaviour
{
    public GameObject Pared;
    public AlarmaRomperse alarma;
    public GameObject Texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Texto.SetActive(true);
        if (alarma.getTerminado())
        {
            Pared.SetActive(false);
            Texto.SetActive(false);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Texto.SetActive(false);
    }
}

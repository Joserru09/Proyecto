using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AlarmaRomperse : MonoBehaviour
{

    public GameObject TextoNecesitoMartillo;
    public GameObject TextoRomper;
    public GameObject Cristal;
    public GameObject TextoPulsarAlarma;
    private bool rota = false;
    private bool terminado = false;
    public InventorySystem inventorySystem;
    public InputManager hand;
    public InventoryItemData inventoryItemData;
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
        if (other.CompareTag("Player"))
        {
            if (!rota)
            TextoNecesitoMartillo.SetActive(true);
            else if(!terminado)TextoPulsarAlarma.SetActive(true);

            if (hand.ultimoItemSeleccionado.itemName.Equals(inventoryItemData.itemName) && inventorySystem.dameInst().HasItem("Martillo"))
            {
                if (!rota)
                {
                    TextoNecesitoMartillo.SetActive(false);
                    TextoRomper.SetActive(true);
                }
                if (Input.GetKey("e") && rota==false)
                {
                    TextoRomper.SetActive(false);
                    Cristal.SetActive(false);
                    TextoPulsarAlarma.SetActive(true);
                    Debug.Log("dentro texto");
                    rota = true;
                   
                   
                }
                if (Input.GetKey("k") && rota && !terminado)
                {
                    TextoPulsarAlarma.SetActive(false);
                    Debug.Log("fuera texto");
                    terminado = true;
                }
            }
            

            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        TextoNecesitoMartillo.SetActive(false);
        TextoRomper.SetActive(false);
        TextoPulsarAlarma.SetActive(false) ;
    }
    public  bool getTerminado()
    {
        return terminado;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class PCPantalla : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pantallaPC;
    public bool entrigger;
    public GameObject TextPcEncendido;
    public GameObject TextArduino;
   // public GameObject TextNeceseitoArduino;
    public GameObject TextChip;
    public GameObject TextNecesitoChip;
    public InputManager hand;
    public InventorySystem inventorySystem;
    public InventoryItemData inventoryItemDataChip;
    public InventoryItemData inventoryItemDataArduino;
    
    public GameObject ArduinoMapa;
    public GameObject ChipMapa;
    private GameObject nuevo;
    public bool arduinoPuesto;
    public bool chipPuesto;
    public bool arduinoEnMano;
    public PasswordCheck pass;
    public GameObject TextRecogerChip;
    public GameObject ChipBueno;
    public GameObject TextAccederPC;
    private bool pulsadoboton = false;
    public Button Boton;
    //PasswordCheck instanciaCheckPass= new PasswordCheck();
    void Start()
    {
        pantallaPC.SetActive(false);
        entrigger = false;
        arduinoPuesto = false;
    chipPuesto = false;
        Boton.onClick.AddListener(OnBotonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

     Debug.Log("dentro trigger");
        if (other.gameObject.CompareTag("Player") && arduinoPuesto == false)
        {
            TextPcEncendido.SetActive(true);
           //  Debug.Log("entras  nooo??");
        }
       else if (other.gameObject.CompareTag("Player") && arduinoPuesto && !chipPuesto)
        {
            TextNecesitoChip.SetActive(true);
            //  Debug.Log("entras  nooo??");
        }
        else if (other.gameObject.CompareTag("Player") && arduinoPuesto && chipPuesto && (!pass.correcta || !pulsadoboton))
        {
            TextAccederPC.SetActive(true);
            //  Debug.Log("entras  nooo??");
        }
        else if (other.gameObject.CompareTag("Player") && arduinoPuesto && chipPuesto && pass.correcta && !ChipBueno.activeSelf && pulsadoboton)
        {
            TextRecogerChip.SetActive(true);
            //  Debug.Log("entras  nooo??");
        }
        try
        {
              //  Debug.Log("entras aqui??");
               //   Debug.Log("con esto: "+ hand.ultimoItemSeleccionado.itemName );
            PonerArduino(other);
        
        }
        catch
        {

        }
        if(arduinoPuesto && !ChipBueno.activeSelf)
        {
            try
            {
                PonerChip(other);
            }
            catch
            {

            }
            
        }
        if (chipPuesto && !ChipBueno.activeSelf)
        {
            
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("h")) {
                pantallaPC.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                TextAccederPC.SetActive(false);
            }
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Escape)) { 
            pantallaPC.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
                TextAccederPC.SetActive(false);
            }
        }
        if (pass.correcta && !ChipBueno.activeSelf && pulsadoboton)
        {
           // TextRecogerChip.SetActive(true);
            TextAccederPC.SetActive(false);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("e")){
                ChipMapa.SetActive(false);
                ChipBueno.SetActive(true);
                TextRecogerChip.SetActive(false);
                
            }
        }





        entrigger = true;



    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sale"+entrigger);
        if (other.gameObject.CompareTag("Player"))
        {
            pantallaPC.SetActive(false);
            Cursor.visible = false;

            entrigger = false;
            TextArduino.SetActive(false);
            TextChip.SetActive(false);
            TextNecesitoChip.SetActive(false);
            TextPcEncendido.SetActive(false);
            TextRecogerChip.SetActive(false);
            Debug.Log("holaaaaaaaa????");
            TextAccederPC.SetActive(false);
        }

    }

    private void PonerArduino(Collider other)
    {
       // Debug.Log("entra a poner arduino con: ");
//Debug.Log(inventorySystem.dameInst().HasItem("Arduino"));
        
        if (other.gameObject.CompareTag("Player") && hand.ultimoItemSeleccionado.itemName.Equals(inventoryItemDataArduino.itemName) && inventorySystem.dameInst().HasItem("Arduino"))
        {
            TextPcEncendido.SetActive(false);
            arduinoEnMano = true;
            TextArduino.SetActive(true);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("q"))
            {
                arduinoEnMano = false;
                TextArduino.SetActive(false);
                arduinoPuesto = true;
                hand.ultimoGameObjectSeleccioando.SetActive(false);
                inventorySystem.Remove(inventoryItemDataArduino);
               
                ArduinoMapa.SetActive(true);
                TextNecesitoChip.SetActive(true);
            }
        }
    }

    private void PonerChip(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && hand.ultimoItemSeleccionado.itemName.Equals(inventoryItemDataChip.itemName) && inventorySystem.dameInst().HasItem("Chip"))
        {
            TextNecesitoChip.SetActive(false);
            TextChip.SetActive(true);
            if (other.gameObject.CompareTag("Player") && Input.GetKeyDown("q"))
            {
                TextChip.SetActive(false);
                chipPuesto = true;
                inventorySystem.Remove(inventoryItemDataChip);
                hand.ultimoGameObjectSeleccioando.SetActive(false);
                ChipMapa.SetActive(true);

            }
        }
    }

    private void OnBotonClick()
    {
        Debug.Log("El botón ha sido pulsado");
        // Aquí puedes realizar las acciones que deseas cuando se pulsa el botón
        pulsadoboton = true;
    }
}


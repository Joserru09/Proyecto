using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public InventoryItemData itemDataLLave;
    public GameObject LlaveMano;
    public GameObject prefabLlave;
    public InventoryItemData itemDataLinterna;
    public GameObject LinternaMano;
    public GameObject prefabLinterna;
    public InventoryItemData itemDataChip;
    public GameObject ChipMano;
    public GameObject prefabChip;
    public InventoryItemData itemDataArduino;
    public GameObject ArduinoMano;
    public GameObject prefabArduino;
    private string ultimaTeclaPulsada;
    public InventoryItemData ultimoItemSeleccionado;
    public GameObject ultimoGameObjectSeleccioando;
    private GameObject nuevo;
    private GameObject prefab;
    public InventoryItemData itemDataMartillo;
    public GameObject MartilloMano;
    public GameObject prefabMartillo;
    private bool linternaActiva = false;

    private void Start()
    {
        // Asegúrate de que tengas una referencia al InventorySystem
        inventorySystem = InventorySystem.Instance;
    }

    private void Update()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                if (inventorySystem.inventory[i - 1].data.Equals(itemDataLinterna))
                {
                    LinternaMano.SetActive(true);
                    LlaveMano.SetActive(false);
                    ArduinoMano.SetActive(false);
                    ChipMano.SetActive(false);
                    MartilloMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataLinterna;
                    ultimoGameObjectSeleccioando = LinternaMano;
                    prefab = prefabLinterna;

                }
                else if (inventorySystem.inventory[i - 1].data.Equals(itemDataLLave))
                {
                    LlaveMano.SetActive(true);
                    LinternaMano.SetActive(false);
                    ArduinoMano.SetActive(false);
                    ChipMano.SetActive(false);
                    MartilloMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataLLave;
                    ultimoGameObjectSeleccioando = LlaveMano;
                    prefab = prefabLlave;
                }
                else if (inventorySystem.inventory[i - 1].data.Equals(itemDataArduino))
                {
                    ArduinoMano.SetActive(true);
                    LinternaMano.SetActive(false);
                    LlaveMano.SetActive(false);
                    ChipMano.SetActive(false);
                    MartilloMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataArduino;
                    ultimoGameObjectSeleccioando = ArduinoMano;
                    prefab = prefabArduino;
                }
                else if (inventorySystem.inventory[i - 1].data.Equals(itemDataChip))
                {
                    ArduinoMano.SetActive(false);
                    LinternaMano.SetActive(false);
                    LlaveMano.SetActive(false);
                    ChipMano.SetActive(true);
                    MartilloMano.SetActive(false);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataChip;
                    ultimoGameObjectSeleccioando = ChipMano;
                    prefab = prefabChip;
                }
                else if (inventorySystem.inventory[i - 1].data.Equals(itemDataMartillo))
                {
                    ArduinoMano.SetActive(false);
                    LinternaMano.SetActive(false);
                    LlaveMano.SetActive(false);
                    ChipMano.SetActive(false);
                    MartilloMano.SetActive(true);
                    ultimaTeclaPulsada = i.ToString();
                    ultimoItemSeleccionado = itemDataMartillo;
                    ultimoGameObjectSeleccioando = MartilloMano;
                    prefab = prefabMartillo;
                }
            }
        }
        if (Input.GetKeyDown("m") && ultimoGameObjectSeleccioando.activeSelf)
        {
            inventorySystem.Remove(ultimoItemSeleccionado);
            ultimoGameObjectSeleccioando.SetActive(false);
            // Vector3 posi= new Vector3(transform.position.x, 0.378f, transform.position.z );
            nuevo = Instantiate(prefab, transform.position, Quaternion.identity);
            nuevo.SetActive(true);
        }
        if (Input.GetKeyDown("x") && linternaActiva)
        {
            LinternaMano.transform.Find("Spot Light").gameObject.SetActive(false);
            linternaActiva = false;
        }
        else if (Input.GetKeyDown("x") && !linternaActiva)
        {
            LinternaMano.transform.Find("Spot Light").gameObject.SetActive(true);
            linternaActiva = true;
        }
    }
}

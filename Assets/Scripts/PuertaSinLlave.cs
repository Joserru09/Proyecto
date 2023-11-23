using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SinLlave : MonoBehaviour
{
    public bool doorOpen = false;   //Ver si la puerta est� abierta o cerrada
    public float doorOpenAngle = 95f; //Angulo de la puerta cuando est� abierta
    public float doorCloseAngle = 0.0f; //Angulo de la puerta cuando est� cerrada
    public float rotSpeed = 3.0f;  //Velocidad de rotacion
    public GameObject door;
    
  
    
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, targetRotation, rotSpeed * Time.deltaTime);
            col.enabled = false;
            col.isTrigger = true;
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            door.transform.localRotation = Quaternion.Slerp(door.transform.localRotation, targetRotation2, rotSpeed * Time.deltaTime);
            col.isTrigger = false;
            col.enabled = true;
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {


        
          
            if (Input.GetKey("q"))
            {
           
            doorOpen = true;
                yield return new WaitForSecondsRealtime(3.0f);
                doorOpen = false;
            }

        }

    }
   


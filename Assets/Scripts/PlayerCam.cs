using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public Transform orientation;
    //public Transform player;
    float Xrotation;
    float Yrotation;

    private void Start()    
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            Yrotation +=mouseX;
            Xrotation -=mouseY;

            Xrotation = Mathf.Clamp(Xrotation, -90f,90f);

            gameObject.transform.rotation=Quaternion.Euler(Xrotation,Yrotation,0);
            orientation.rotation=Quaternion.Euler(0,Yrotation,0);   //ROTA EL OBJECT ORIENTATION RESPECTO AL EJE Y
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Video;

public class PasswordCheck : MonoBehaviour
{
    public InputField passwordInputField;
    public string correctPassword = "1234";
    public bool correcta;
    public GameObject textoContraCorrect;
    public GameObject textoContraIncorrect;
    public GameObject pcPantallaScript;
    public GameObject AnimacionCargar;
    public GameObject PantallaLogin;
    public GameObject ordenador;
    public GameObject Escritorio;
    public VideoPlayer videoHack;
    public GameObject botonBlock;
    public GameObject botonDesblock;
    public GameObject FiltroColor;
    public GameObject FiltroApp;
    void Start()
    {
        textoContraCorrect.SetActive(false);
        textoContraIncorrect.SetActive(false);
        AnimacionCargar.SetActive(false);
        PantallaLogin.SetActive(true);
        
    }

    public void CheckPassword()
    {
        PCPantalla pcPantalla = pcPantallaScript.GetComponent<PCPantalla>();
        if ( pcPantalla != null && pcPantalla.entrigger && !correcta &&passwordInputField.text == correctPassword)
        {
            Debug.Log("Contrase�a correcta");
            correcta = true;
            textoContraIncorrect.SetActive(false);
            textoContraCorrect.SetActive(true) ;
            AnimacionCargar.SetActive(true);
            StartCoroutine(PausarPorTresSegundos());
        }
        else
        {
            Debug.Log("Contrase�a incorrecta");
            textoContraCorrect.SetActive(false) ;
            textoContraIncorrect.SetActive(true);
        }
    }
    public void Exit()
    {
        ordenador.SetActive(false);
    }
    public void abrirApp()
    {
        Escritorio.SetActive(false);
        botonBlock.SetActive(true);
        videoHack.Play();
        videoHack.Stop();
    }
    public void cerrarApp()
    {
        botonDesblock.SetActive(false);
        Escritorio.SetActive(true);
        FiltroApp.SetActive(true);
    }
    public void Hackear()
    {
        Escritorio.SetActive(false);
        botonBlock.SetActive(false);
        videoHack.Play();
        videoHack.loopPointReached += parar;
        
        
    }
    public void parar( VideoPlayer vp){
            vp.Stop();
            botonDesblock.SetActive(true);
        }
    IEnumerator PausarPorTresSegundos()
    {
        yield return new WaitForSeconds(3.0f);
        PantallaLogin.SetActive(false);
        FiltroColor.SetActive(false);
    }
}
    
  

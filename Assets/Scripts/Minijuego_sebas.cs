using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Minijuego_sebas : MonoBehaviour
{
    public string nombre;
    public GameObject cuadrado;
    Color color_cuadrado;
    public float velocidadllave;
    private float velocidadllaveini;
    private float limiteIzq;
    private float limiteDer;
    private MeshRenderer color_cubo;
    private float cube_limiteCentral;
    private float cube_limiteDer;
    private float dist_cubo;
    private short nivelestotales;
    private short nivelactual=1;
    public short vidas;
    private short vidasaux;
    public GameObject triang;
    private float rand;
    private bool dir=true;
    private bool gaming=false;
    private bool genround=false;
    private float scale;
    private float [] escalaNivs;
    //CANVAS DEL TEXTO
    public GameObject TextAbrirCofre;
    public GameObject JuegoNullObject;
    public float escalaNiv1;
    public float escalaNiv2;
    public float escalaNiv3;
    public GameObject CoraMask;
    private float CoraMaskPosIniX;
    void Start()
    {
    CoraMaskPosIniX=CoraMask.transform.position.x;
    color_cubo=GameObject.Find("sebas_rangoacierto").GetComponent<MeshRenderer>();
    limiteDer=GameObject.Find("limD").transform.position.x;   //USAMOS EJE Y & Z
    limiteIzq=GameObject.Find("limI").transform.position.x;
    GameObject.Find("JuegoSebas").SetActive(false);
    escalaNivs=new float[2];
    scale=escalaNiv1;
    escalaNivs[0]=escalaNiv2;
    escalaNivs[1]=escalaNiv3;
    nivelestotales=3;
    velocidadllaveini=velocidadllave;
    vidasaux=vidas;

    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log(gameObject.transform.position);
        if(gaming){
            if(dir){
            triang.transform.position=new Vector3(triang.transform.position.x-velocidadllave*Time.deltaTime,triang.transform.position.y,triang.transform.position.z);
            }
            else {
            triang.transform.position=new Vector3(triang.transform.position.x+velocidadllave*Time.deltaTime,triang.transform.position.y,triang.transform.position.z);
            }
            if(triang.transform.position.x<=limiteIzq){
                dir=false;
            } else if(triang.transform.position.x>=limiteDer) {
                dir=true;
            }
            if(Input.GetKeyDown(KeyCode.Space)){
                gaming=false;
                //Debug.Log((triang.transform.position.x)+">="+(cube_limiteCentral-dist_cubo)+"\n"+(triang.transform.position.x)+"<="+(cube_limiteCentral+dist_cubo));
                if(triang.transform.position.x>=cube_limiteCentral-dist_cubo && triang.transform.position.x<=cube_limiteCentral+dist_cubo){
                    WinRound();
                } else {
                    LoseRound(--vidasaux);
                }
            }
        }else if(genround) { //tratamiento de la situacion
            genround=false;
            Debug.Log("GENROUD: ");
            color_cubo.material.color=Color.blue;
            
            //scale=Random.Range(primer_scale_min ,primer_scale_max);


            cuadrado.transform.localScale=new Vector3(scale,cuadrado.transform.localScale.y,cuadrado.transform.localScale.z);
            //primer_scale_max=.7f*scale;

            cube_limiteCentral=cuadrado.transform.position.x;
            cube_limiteDer=GameObject.Find("Cube_D").transform.position.x;
            dist_cubo=cube_limiteDer-cube_limiteCentral;
            
            rand=Random.Range(limiteIzq ,limiteDer);
            while(rand-dist_cubo<limiteIzq || rand+dist_cubo>limiteDer){
                rand=Random.Range(limiteIzq ,limiteDer);
            }
            cuadrado.transform.position=new Vector3(rand,cuadrado.transform.position.y,cuadrado.transform.position.z);
            cube_limiteCentral=cuadrado.transform.position.x;
            gaming=true;            
            }
        
    }

    void WinRound(){
        nivelactual++;
        color_cubo.material.color=Color.green;
        //primer_scale_min=primer_scale_min-0.20f*primer_scale_min;


        velocidadllave=1.5f*velocidadllave;
        if(nivelactual!=nivelestotales+1){
            if(nivelactual==1)
            scale=escalaNiv1;
            else{
            scale=escalaNivs[nivelactual-2];
            }
            Debug.Log(scale);
            genround=true;
        }
        else CodigoVictoria();
    }
    void LoseRound(int vidas){
        color_cubo.material.color=Color.red;
        CoraMask.transform.position=new Vector3(CoraMask.transform.position.x-0.078f,CoraMask.transform.position.y,CoraMask.transform.position.z);   
        Debug.Log("LOSE");
        if(vidas!=0)gaming=true;
        else CodigoDerrota();
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name=="Hand"){
                TextAbrirCofre.SetActive(true);

            if(Input.GetKeyDown("q")){

                JuegoNullObject.SetActive(true);
                TextAbrirCofre.SetActive(false);
                genround=true;
                gameObject.GetComponent<Collider>().enabled=false;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
            if (other.gameObject.name=="Hand"){
            TextAbrirCofre.SetActive(false);
            }
    }
    void CodigoVictoria(){
        Debug.Log("WIN");
        transform.position=new Vector3(444.373993f,1.32799911f,564.548279f);
        JuegoNullObject.SetActive(false);
        
    }
    void CodigoDerrota(){
        CoraMask.transform.position=new Vector3(CoraMaskPosIniX,CoraMask.transform.position.y,CoraMask.transform.position.z);
        Debug.Log("DERROTA");
        gameObject.GetComponent<Collider>().enabled=true;
        JuegoNullObject.SetActive(false);
        velocidadllave=velocidadllaveini;
        scale=escalaNiv1;
        vidasaux=vidas;
        nivelactual=1;


    }

}

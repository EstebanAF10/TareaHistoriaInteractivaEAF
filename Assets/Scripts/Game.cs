using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public Opcion bancoPreguntas;
    public TextMeshProUGUI enunciado;
    public TextMeshProUGUI[] opciones;
    public int nivelPregunta;
    public Opcion preguntaActual;
    //public PanelComplementario panelComplementario;
    public Button[] btnRespuesta;
    public static string enunciadoFinal;

    // Start is called before the first frame update
    void Start()
    {
        nivelPregunta = 0;
        cargarBancoPreguntas();
        preguntaActual = bancoPreguntas;
        setPregunta();

        
    }

    public void setPregunta(){

        enunciado.text = preguntaActual.enunciado; //Aqui se asigna el enunciado en el juego

        for(int i = 0; i < opciones.Length; i++)
        {
            opciones[i].text = preguntaActual.opciones[i].textoOpcion;
        }
    }

    // public void setEnunciadoFinal(){
    //     enunciado.text = preguntaActual.enunciado;
    // }

    public void cargarBancoPreguntas(){
        try{

            bancoPreguntas = JsonConvert.DeserializeObject<Opcion>(File.ReadAllText(Application.streamingAssetsPath + "/QuestionBank.json"));

        }catch(System.Exception ex)
        {
            Debug.Log(ex.Message);
            enunciado.text = ex.Message;
        }
    }

    public void evaluarPregunta(int respuestaJugador) //Solo puede ser  0 o 1
    {
        nivelPregunta ++;

        preguntaActual = preguntaActual.opciones[respuestaJugador];
        if (preguntaActual.esFinal)
        {
            Debug.Log(preguntaActual.enunciado);
            enunciadoFinal = preguntaActual.enunciado;
            SceneManager.LoadScene("Final");
        
        }
        else
        {
            setPregunta();
        }
    }
}

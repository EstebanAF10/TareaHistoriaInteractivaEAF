using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class EnunciadoFinal : MonoBehaviour
{
    public TextMeshProUGUI enunciado;
    public int nivelPregunta;
    // public Opcion preguntaActual;

    // Start is called before the first frame update
    void Start()
    {
        enunciado.text = Game.enunciadoFinal;
    }

    
}

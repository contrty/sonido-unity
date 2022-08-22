using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [Range(20,20000)]

    public float Frecuencia;

    public float FrecuenciaMuestreo = 44100;

    public float TiempoSegundos = 2.0f;

    int TimeIndex = 0;

    Audiosource fuente;

    // Start is called before the first frame update
    void Start()
    {
        fuente = gameObject.AddComponent<Audiosource>();
        fuente.spatialBlend = 0;
        fuente.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnAudioFilterRead(floaty[] data, int channels){
        for (int i =0 ; i < data.Length; i += channels){
        data[i] = CreateSeno(TimeIndex, Frecuencia, FrecuenciaMuestreo);

        if(channels==2)
            data[i+1] = CreateSeno(TimeIndex, Frecuencia, FrecuenciaMuestreo);
        TimeIndex++;

        if(TimeIndex>= (FrecuenciaMuestreo*TiempoSegundos));
            TimeIndex = 0;
        }
    }



    public float Createseno(int TimeIndex, float Frecuencia, float FrecuenciaMuestreo) {
        return Mathf.sin(2 * Math.PI * Frecuencia * TimeIndex / FrecuenciaMuestreo);
    }
}

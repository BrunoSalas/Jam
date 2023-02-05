using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [HideInInspector]
    public bool fin = false;

    //variable para que vaya mas rapido la variable
    public float multi;

    //variable que guarda en que valor se quedo la barra
    public float valor;

    //variable para saber si se detiene el slider
    public bool detenerse;
    [HideInInspector]
    public bool pasar;
    public bool init;

    private void Update()
    {
        if (detenerse == true)
        {
            //this.GetComponent<Slider>().wholeNumbers = true;

            //switch para que debe dar un valor segun que parte de la barra esta 
            switch (valor)
            {
                case float n when (n >= 0 && n <= 15):
                    pasar = false;
                    init = false;
                    break;
                case float n when (n >= 16 && n <= 41):
                    pasar = true;
                    init = false;
                    break;
                case float n when (n >= 42 && n <= 60):
                    pasar = false;
                    init = false;
                    break;

            }
        }
        else if (detenerse == false && init)
        {
            //todo eso es ppara que el slider se mueva
            if (fin == false)
            {
                this.GetComponent<Slider>().value = this.GetComponent<Slider>().value + multi * Time.deltaTime;
            }

            else if (fin == true)
            {
                this.GetComponent<Slider>().value = this.GetComponent<Slider>().value - multi * Time.deltaTime;
            }

            if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().minValue)
            {
                fin = false;
            }
            else if (this.GetComponent<Slider>().value == this.GetComponent<Slider>().maxValue)
            {
                fin = true;

            }
        }

    }

    public void Detener()
    {
        detenerse = true;
        valor = this.GetComponent<Slider>().value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCountRoot : MonoBehaviour
{
    public bool uno;
    public bool dos;
    public bool tres;
    public bool cuatro;
    public bool fase1, fase2, fase3, fase4;
    public GameObject unoGameObject;
    public GameObject dosGameObject;
    public GameObject tresGameObject;
    public GameObject cuatroGameObject;
    public bool paso;
    public bool init;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(uno && !dos && !tres && !cuatro)
        {
            fase1 = true;
        }
        else
        {
            paso = false;
        }
        if (dos && !tres && !cuatro && uno)
        {
            fase2 = true;
        }
        else
        {
            paso = false;
        }
        if (tres && !cuatro && uno && dos)
        {
            fase3 = true;
        }
        else
        {
            paso = false;
        }
        if (cuatro && tres && dos && uno && fase1 && fase2 && fase3)
        {
            paso = true;
            fase4 = true;
        }
        else
        {
            paso = false;
        }
    }
    public void Uno()
    {
        uno = true;
    }
    public void Dos()
    {
        dos = true;
    }
    public void Tres()
    {
        tres = true;
    }
    public void Cuatro()
    {
        cuatro = true;
    }

    public void Reset()
    {
        uno = false;
        dos = false;
        tres = false;
        cuatro = false;
        fase1 = false;
        fase2 = false;
        fase3 = false;
        fase4 = false;
    }
}

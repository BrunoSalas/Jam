using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class puntos : MonoBehaviour
{
    GameObject playerObject;
    Player player;
    GameObject camara;
    PointClick camera;
    public int vida;
    public int conejo;
    public int zanahoria;
    public int veterraga;
    public int kion;
    public TMP_Text cone;
    public TMP_Text pasos;
    public TMP_Text vidas;
    public GameObject a;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        camera = camara.GetComponent<PointClick>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        conejo = player.conejos;
        zanahoria = player.zanahoria;
        veterraga = player.veterraga;
        kion = player.kion;
        vida = player.vida;
        if(vida <= 0)
        {
            a.SetActive(true);
        }
        if(conejo >= 4)
        {
            b.SetActive(true);
        }
        if(camera.pasosHechos - camera.pasosHechos <= 0)
        {
            a.SetActive(true);
        }
        cone.text = conejo.ToString() + "/" + "4";
        vidas.text = vida.ToString();
        pasos.text = (camera.maximoPasos - camera.pasosHechos).ToString(); ;
        
    }
}

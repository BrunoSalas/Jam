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
    public bool pasoAtras;
    public bool init;
    public float softened = 3;
    bool desaparecer;
    GameObject playerObject;
    public MainObstaculos mainObstaculos;
    Player player;
    // Start is called before the first frame update
    void Start()
    {

        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CanvasGroup>().alpha > 0)
        {
            if (fase4)
            {
                DisappearObstacule();
                StartCoroutine(Destroy());
            }
            if (pasoAtras)
            {
                DisappearObstacule();
                mainObstaculos.Comprobante();
                init = false;   desaparecer = true;
            }
            if(desaparecer)
            {

                DisappearObstacule();
            }
        }
        
        if(GetComponent<CanvasGroup>().alpha < 0)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            GetComponent<CanvasGroup>().interactable = false;
        }
    }

    public void DisappearObstacule()
    {

        var alphatierra = GetComponent<CanvasGroup>().alpha;

        //var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        // var alphaText = textAlpha.GetComponent<Text>().color;

        alphatierra = Mathf.Lerp(alphatierra, 0f, softened * Time.deltaTime);
        if (alphatierra <= 0.1f)
        {
            alphatierra = 0f;
            pasoAtras = false;
            desaparecer = false;
        }
        //alphaText.a = 0f;
        GetComponent<CanvasGroup>().alpha = alphatierra;
        //textAlpha.GetComponent<Text>().color = alphaText;
    }
    public void Uno()
    {
        if (init)
        {
            uno = true;
            fase1 = true;
        }
    }
    public void Dos()
    {
        if (init)
        {
            if (uno)
            {
                dos = true;
                fase2 = true;
            }
            else
                pasoAtras = true;
        }
    }
    public void Tres()
    {
        if (init)
        {
            if (dos && uno)
            {
                tres = true;
                fase3 = true;
            }
            else
                pasoAtras = true;
        }
    }
    public void Cuatro()
    {
        if (init)
        {
            if (dos && tres && uno)
            {
                cuatro = true;
                fase4 = true;
            }
            else
                pasoAtras = true;
        }
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
    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f); desaparecer = true;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(player.raiz);
        mainObstaculos.Comprobante();
    }
}

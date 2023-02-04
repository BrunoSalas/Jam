using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerExcarvar : MonoBehaviour
{
    public ControllerCount controllerCount;
    public MainObstaculos mainObstaculos;
    GameObject playerObject;
    Player player;
    [HideInInspector]
    public CanvasGroup excarvar;
    public float softened;
    public bool paso;
    bool desaparecer;
    public GameObject tierraObject;
    // Start is called before the first frame update
    void Start()
    {
        excarvar = GetComponent<CanvasGroup>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (excarvar.alpha > 0)
        {
            paso = controllerCount.paso;
            if (paso)
                StartCoroutine(Destroy());
            if(!paso && controllerCount.atrasPaso)
            {
                mainObstaculos.Comprobante();
            }



        }
        else 
        {
            excarvar.blocksRaycasts = false;
            excarvar.interactable = false;
        }
        if (desaparecer)
        {
            DisappearObstacule();
        }
        else
        {


        }
        if(!controllerCount.init)
        {

            StartCoroutine(Disappear());
        }
    }
    public void DisappearObstacule()
    {

        var alphatierra = excarvar.GetComponent<CanvasGroup>().alpha;

        //var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        // var alphaText = textAlpha.GetComponent<Text>().color;

        alphatierra = Mathf.Lerp(alphatierra, 0f, softened * Time.deltaTime);
        if (alphatierra <= 0.1f)
        {
            alphatierra = 0f;
            desaparecer = false;
        }
        //alphaText.a = 0f;
        excarvar.GetComponent<CanvasGroup>().alpha = alphatierra;
        //textAlpha.GetComponent<Text>().color = alphaText;
    }
    public IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f); desaparecer = true;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(player.tierra);
        mainObstaculos.Comprobante();
    }
}

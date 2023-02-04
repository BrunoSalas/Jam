using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerRama : MonoBehaviour
{
    [HideInInspector]
    public SliderController sliderController;
    GameObject playerObject;
    Player player;
    [HideInInspector]
    public CanvasGroup rama;
    public float softened;
    [HideInInspector]
    public bool paso;
    bool desaparecer;
    public GameObject ramaObject;
    // Start is called before the first frame update
    void Start()
    {
        rama = GetComponent<CanvasGroup>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rama.alpha > 0)
        {
            paso = sliderController.fallo;

            
        }
        else
        {
            rama.blocksRaycasts = false;
            rama.interactable = false;
        }
        if (desaparecer)
        {
            DisappearObstacule();
        }
        else
        {


        }
    }
    public void DisappearObstacule()
    {

        var alphaRama = rama.GetComponent<CanvasGroup>().alpha;

        //var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        // var alphaText = textAlpha.GetComponent<Text>().color;
        
        alphaRama = Mathf.Lerp(alphaRama, 0f, softened * Time.deltaTime);
        if (alphaRama <= 0.1f)
        {
            alphaRama = 0f;
            desaparecer = false;
            sliderController.detenerse = false;
            if(paso)
                StartCoroutine(Destroy());
        }
        //alphaText.a = 0f;
        rama.GetComponent<CanvasGroup>().alpha = alphaRama;
        //textAlpha.GetComponent<Text>().color = alphaText;
    }
    public void hola()
    {
        StartCoroutine(Disappear());
    }
    public  IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);desaparecer = true;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(player.rama);
    }
}

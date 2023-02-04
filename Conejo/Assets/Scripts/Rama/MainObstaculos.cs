using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObstaculos : MonoBehaviour
{
    [HideInInspector]
    public ControllerRama controllerRama;
    public bool initRama;
    GameObject playerObject;
    Player player;
    GameObject camera;
    PointClick pointClick;
    bool ramaPaso;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        pointClick = camera.GetComponent<PointClick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(initRama)
        {
            InitObstaculeRama();
        }
    }
    public void InitObstaculeRama()
    {
        var alphaRama = controllerRama.rama.GetComponent<CanvasGroup>().alpha;

        //var alphaBallon = ballonAlpha.GetComponent<RawImage>().color;

        // var alphaText = textAlpha.GetComponent<Text>().color;

        alphaRama = Mathf.Lerp(alphaRama, 1f, controllerRama.softened * Time.deltaTime);

        //alphaText.a = Mathf.Lerp(alphaText.a, 1f, softened * Time.deltaTime);

        if (alphaRama >= 0.9f)
        {
            //alphaText.a = 1f;
            alphaRama = 1f;
            controllerRama.rama.interactable = true;
            controllerRama.rama.blocksRaycasts = true;
            initRama = false;
        }
        // Debug.Log(alphaBallon);
        controllerRama.rama.GetComponent<CanvasGroup>().alpha = alphaRama;
        //ballonAlpha.GetComponent<RawImage>().color = alphaBallon;
        //textAlpha.GetComponent<Text>().color = alphaText;
    }
    public void ComprobanteRama()
    {
       ramaPaso  = controllerRama.paso;
        if(ramaPaso)
        {
            StartCoroutine(Seguir());
        }
        else
        {
            StartCoroutine(Retroceder());
        }
    }

    IEnumerator Seguir()
    {
        yield return new WaitForSeconds(0.8f);
        player.navMesh.speed = 3.5f;
        GameObject lugar = Instantiate(pointClick.lugar, new Vector3(pointClick.siguienteVec.x, pointClick.siguienteVec.y + 1, pointClick.siguienteVec.z), Quaternion.identity);
        player.navMesh.SetDestination(lugar.transform.position);
    }
    IEnumerator Retroceder()
    {
        yield return new WaitForSeconds(0.8f);
        player.navMesh.speed = 3.5f;
       GameObject lugar =  Instantiate(pointClick.lugar,  new Vector3(pointClick.anteriorVec.x, pointClick.anteriorVec.y + 1, pointClick.anteriorVec.z), Quaternion.identity);
        player.navMesh.SetDestination(lugar.transform.position);
    }
}

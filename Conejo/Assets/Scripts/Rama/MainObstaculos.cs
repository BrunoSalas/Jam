using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObstaculos : MonoBehaviour
{
    public ControllerRama controllerRama;
    public ControllerExcarvar controllerExcarvar;
    public ControllerCountRoot controllerCountRoot;
    public bool initRama;
    public bool initExcarvar;
    public bool initRoot;
    GameObject playerObject;
    Player player;
    GameObject camera;
    PointClick pointClick;
    [SerializeField]
    bool ramaPaso;
    [SerializeField]
    bool tierraPaso;
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
        if(initExcarvar)
        {
            InitObstaculeExcarvar();
        }
        if(initRoot)
        {
            InitObstaculeRoot();
        }
    }
    public void InitObstaculeRoot()
    {
        var alphaRaiz = controllerCountRoot.GetComponent<CanvasGroup>().alpha;

        alphaRaiz = Mathf.Lerp(alphaRaiz, 1f, controllerExcarvar.softened * Time.deltaTime);

        if (alphaRaiz >= 0.8f)
        {
            //alphaText.a = 1f;
            alphaRaiz = 1f;
            controllerCountRoot.GetComponent<CanvasGroup>().interactable = true;
            controllerCountRoot.GetComponent<CanvasGroup>().blocksRaycasts = true;
            initRoot = false;
        }
        // Debug.Log(alphaBallon);
        controllerCountRoot.GetComponent<CanvasGroup>().alpha = alphaRaiz;
    }
    public void InitObstaculeExcarvar()
    {
        var alphaTierra = controllerExcarvar.excarvar.GetComponent<CanvasGroup>().alpha;

        alphaTierra = Mathf.Lerp(alphaTierra, 1f, controllerExcarvar.softened * Time.deltaTime);

        if (alphaTierra >= 0.8f)
        {
            //alphaText.a = 1f;
            alphaTierra = 1f;
            controllerExcarvar.excarvar.interactable = true;
            controllerExcarvar.excarvar.blocksRaycasts = true;
            initExcarvar = false;
        }
        // Debug.Log(alphaBallon);
        controllerExcarvar.excarvar.GetComponent<CanvasGroup>().alpha = alphaTierra;
    }
    public void InitObstaculeRama()
    {
        var alphaRama = controllerRama.rama.GetComponent<CanvasGroup>().alpha;

        alphaRama = Mathf.Lerp(alphaRama, 1f, controllerRama.softened * Time.deltaTime);

        if (alphaRama >= 0.9f)
        {
            alphaRama = 1f;
            controllerRama.rama.interactable = true;
            controllerRama.rama.blocksRaycasts = true;
            initRama = false;
        }
        controllerRama.rama.GetComponent<CanvasGroup>().alpha = alphaRama;
    }
    public void Boton()
    {
        StartCoroutine(Comprobar());
      
    }
    public void Comprobante()
    {
        StartCoroutine(Comprobar());
    }
    IEnumerator Comprobar()
    {
        yield return new WaitForSeconds(0.5f);
        ramaPaso = controllerRama.paso;
        tierraPaso = controllerExcarvar.paso;
        if (ramaPaso || tierraPaso)
        {
            Debug.Log("qwe");
            StartCoroutine(Seguir());
        }
        else
        {
            Debug.Log("weq");
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

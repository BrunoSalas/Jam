using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public int zanahoria;
    public int veterraga;
    public int kion;
    [SerializeField]
    LayerMask suelo;
    public GameObject zona;
    GameObject mainObstac;
    [HideInInspector]
    public GameObject rama;
    [HideInInspector]
    public GameObject tierra;
    [HideInInspector]
    public GameObject raiz;
    public int vida;
    MainObstaculos mainObstaculos;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        mainObstac = GameObject.FindGameObjectWithTag("MainObstacule");
        mainObstaculos = mainObstac.GetComponent<MainObstaculos>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,2f,suelo))
        {
            if(hit.collider.gameObject.tag == "Zonas")
            {

                zona = hit.collider.gameObject;
            }
            if (hit.collider.gameObject.tag == "ZonasMedias")
            {
                hit.collider.gameObject.GetComponent<zonaMedia>().encima = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zanahoria"))
        {
            zanahoria += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Kion"))
        {
            kion += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Veterraga"))
        {
            veterraga += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("RamaObstacule"))
        {
            navMesh.speed = 0;
            mainObstaculos.initRama = true;
            mainObstaculos.controllerRama.sliderController.init = true;
            rama = other.gameObject;
        }
        if(other.CompareTag("ExcarvarObstacule"))
        {
            navMesh.speed = 0;
            mainObstaculos.initExcarvar = true;
            mainObstaculos.controllerExcarvar.controllerCount.init = true;
            tierra = other.gameObject;
        }
        if (other.CompareTag("RaizObstacule"))
        {
            navMesh.speed = 0;
            mainObstaculos.initRoot = true;
            mainObstaculos.controllerCountRoot.init = true;
            raiz = other.gameObject;
        }
        if (other.CompareTag("Hazard"))
        {
            vida--;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RamaObstacule"))
        {
            mainObstaculos.controllerRama.sliderController.init = false;
        }
    }
}

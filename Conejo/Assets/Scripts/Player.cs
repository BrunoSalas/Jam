using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public int zanahoria;
    [SerializeField]
    LayerMask suelo;
    public GameObject zona;
    GameObject mainObstac;
    [HideInInspector]
    public GameObject rama;
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
            zona = hit.collider.gameObject;
            if(hit.collider.gameObject.tag == "Zonas")
            {

            }
            if (hit.collider.gameObject.tag == "ZonasMedias")
            {

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zanahoria"))
        {
            zanahoria += 1;
        }
        if (other.CompareTag("RamaObstacule"))
        {
            navMesh.speed = 0;
            mainObstaculos.initRama = true;
            mainObstaculos.controllerRama.sliderController.init = true;
            rama = other.gameObject;
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

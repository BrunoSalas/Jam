using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour
{
    public LayerMask camino;
    public GameObject lugar;
    public float y;
    public Player player;
    public bool llendo;
    public int maximoPasos;
    int pasosHechos;
    [HideInInspector]
    public GameObject siguiente;
    [HideInInspector]
    public GameObject anterior;
    [HideInInspector]
    public Vector3 siguienteVec;
    [HideInInspector]
    public Vector3 anteriorVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(1) && Physics.Raycast(ray,out hit,Mathf.Infinity,camino) && pasosHechos < maximoPasos)
        {
            for (int i = 0; i < player.zona.GetComponent<Zonas>().zonas.Length; i++)
            {
                if(hit.collider.gameObject == player.zona.GetComponent<Zonas>().zonas[i])
                {
                    anterior = player.zona;
                    anteriorVec = player.zona.transform.position;
                    if (!llendo)
                    {
                        pasosHechos++;
                        Instantiate(lugar, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + y, hit.collider.transform.position.z), Quaternion.identity);
                        player.navMesh.SetDestination(hit.collider.transform.position);
                        siguiente = hit.collider.gameObject;
                        siguienteVec = hit.collider.transform.position;
                    }
                }
                else
                {
                    Debug.Log("aqui no");
                }
            }
           
        }
        else if(pasosHechos == maximoPasos)
        {
            Debug.Log("pasos terminados");
        }
    }
}

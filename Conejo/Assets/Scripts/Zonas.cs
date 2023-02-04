using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zonas : MonoBehaviour
{

    public GameObject[] zonas;
    public GameObject niebla;
    public bool encima;
    public bool cerca;
    public bool mitad;
    bool una;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!encima && !cerca)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignorar");
            StartCoroutine(NeblinaFadeOn());
        }
        else
            StartCoroutine(LayerAsign());
        if (encima)
        {
            niebla.GetComponent<ParticleSystem>().loop = false;

            foreach (GameObject nieblas in zonas)
            {
                nieblas.GetComponent<Zonas>().cerca = true;
            }
        }
        else
        {
            foreach (GameObject nieblas in zonas)
            {
                if (una == false)
                {
                    una = nieblas.GetComponent<Zonas>().encima;
                    if (una)
                    {
                        cerca = true;
                        niebla.GetComponent<ParticleSystem>().loop = false;
                        StartCoroutine(ui());
                    }
                    else
                    {
                        
                        StartCoroutine(NeblinaFadeOn());
                    }
                }
                if (cerca)
                {

                    StartCoroutine(ai(nieblas));
                }
            }
        }

    }

    IEnumerator LayerAsign()
    {
        yield return new WaitForSeconds(2);
        gameObject.layer = LayerMask.NameToLayer("Camino");
    }
    public IEnumerator NeblinaFadeOn()
    {
        yield return new WaitForSeconds(0.6f);
        if (!mitad)
        {
            if (!cerca && !encima &&
                !niebla.GetComponent<ParticleSystem>().loop)
            {
                niebla.GetComponent<ParticleSystem>().loop = true;
                niebla.GetComponent<ParticleSystem>().Play();
            }
        }
        yield return null;

    }
    IEnumerator ai(GameObject niebla)
    {
        yield return new WaitForSeconds(1f);
        if(niebla.GetComponent<Zonas>().encima)
        {
            cerca = true;
        }
        else
        {
            cerca = false;
        }
    }
    IEnumerator ui()
    {
        yield return new WaitForSeconds(1f);
        una = false;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = true;
            cerca = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = false;
           // StartCoroutine(NeblinaFadeOn());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.up * 2f);
    }
}

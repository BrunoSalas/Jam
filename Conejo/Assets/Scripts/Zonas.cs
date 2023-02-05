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
        if(cerca || mitad)
        {

            niebla.GetComponent<ParticleSystem>().loop = false;
        }
        else
        {
            for (int i = 0; i < zonas.Length; i++)
            {
            
                if (una == false)
                {
                    una = GetComponent<Zonas>().encima;
                    if (una)
                    {
                        cerca = true;
                        niebla.GetComponent<ParticleSystem>().loop = false;
                        niebla.GetComponent<ParticleSystem>().Stop();
                        StartCoroutine(ui());
                    }
                    else
                    {
                        
                        StartCoroutine(NeblinaFadeOn());
                    }
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
    IEnumerator ai()
    {
        yield return new WaitForSeconds(1.5f);
        if (!mitad)
        {
            foreach (GameObject nieblas in zonas)
            {
                nieblas.GetComponent<Zonas>().cerca = false;
            }
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
            StartCoroutine(ai());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.up * 2f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zonas : MonoBehaviour
{

    public GameObject[] zonas;
    public GameObject niebla;
    public bool encima;
    public bool cerca;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public IEnumerator NeblinaFadeIn()
    {
        yield return new WaitForSeconds(1f);
        if (encima && !cerca)
        {
            foreach (GameObject nieblas in zonas)
            {
                nieblas.GetComponent<Zonas>().cerca = true;
                nieblas.GetComponent<Zonas>().niebla.GetComponent<ParticleSystem>().loop = false;
            }
        }
        else
        {
            //niebla.GetComponent<ParticleSystem>().loop = true;
            //niebla.GetComponent<ParticleSystem>().Play();
        }

        yield return null;
    }
    public IEnumerator NeblinaFadeOn()
    {
        yield return new WaitForSeconds(1.5f);
        foreach (GameObject nieblas in zonas)
        {
            if (!cerca && !nieblas.GetComponent<Zonas>().encima)
            {
                nieblas.GetComponent<Zonas>().cerca = false;
                nieblas.GetComponent<Zonas>().niebla.GetComponent<ParticleSystem>().loop = true;
                nieblas.GetComponent<Zonas>().niebla.GetComponent<ParticleSystem>().Play();
                Debug.Log(gameObject.name);
            }
        }

        yield return null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = true;
            cerca = false;
            niebla.GetComponent<ParticleSystem>().loop = false; 
            StartCoroutine(NeblinaFadeIn());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = false;
            StartCoroutine(NeblinaFadeOn());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.up * 2f);
    }
}

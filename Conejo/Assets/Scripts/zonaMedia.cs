using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaMedia : MonoBehaviour
{
    public GameObject[] zonas;
    public bool encima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(encima)
        {
            foreach (GameObject nieblas in zonas)
            {
                nieblas.GetComponent<Zonas>().mitad = true;
                nieblas.GetComponent<Zonas>().niebla.GetComponent<ParticleSystem>().loop = false;
            }
        }
    }
    public IEnumerator NeblinaFadeIn()
    {
        foreach (GameObject nieblas in zonas)
        {
            nieblas.GetComponent<Zonas>().mitad = false;
        }
        

        yield return null;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = false;
            StartCoroutine(NeblinaFadeIn());
        }
    }
}

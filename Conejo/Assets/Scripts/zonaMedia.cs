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
    }
    public IEnumerator NeblinaFadeIn()
    {
        yield return new WaitForSeconds(1f);
        if (encima)
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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = true;
            StartCoroutine(NeblinaFadeIn());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            encima = false;
        }
    }
}

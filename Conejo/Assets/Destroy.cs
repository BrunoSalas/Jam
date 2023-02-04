using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("MainCamera");
        point.GetComponent<PointClick>().llendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {

            StartCoroutine(AutoDestrucion());
        }
    }
    private IEnumerator AutoDestrucion()
    {
        point.GetComponent<PointClick>().llendo = false;
        Destroy(gameObject);
        yield return null;
    }
}

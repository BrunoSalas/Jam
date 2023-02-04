using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerLoot : MonoBehaviour
{
    [SerializeField]
    bool aparecerZanahoria;
    public GameObject zanahoria;
    // Start is called before the first frame update
    void Start()
    {
        if(aparecerZanahoria)
        {
            Instantiate(zanahoria,new Vector3( transform.position.x, transform.position.y + 1, transform.position.z),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

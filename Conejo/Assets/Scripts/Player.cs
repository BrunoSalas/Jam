using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public int zanahoria;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zanahoria"))
        {
            zanahoria += 1;
        }
    }

}

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
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,2f,suelo))
        {
            zona = hit.collider.gameObject;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zanahoria"))
        {
            zanahoria += 1;
        }
    }

}

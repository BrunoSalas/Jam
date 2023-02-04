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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(1) && Physics.Raycast(ray,out hit,Mathf.Infinity,camino))
        {
            if (!llendo)
            {
                Instantiate(lugar, new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + y, hit.collider.transform.position.z), Quaternion.identity);
                player.navMesh.SetDestination(hit.collider.transform.position);
            }
        }
    }
}

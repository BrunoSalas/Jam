using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAConejo : MonoBehaviour
{
    public Conejos conejos;
    GameObject playerObject;
    Player player;
    public GameObject canvas;
    public Camera camera;
    public float duracion;
    public float destruccion;
    [SerializeField]
    bool faltaVeterrag, faltaZanaho, faltaKion;
    [SerializeField]
    bool cerca;
    int cont = 0;
    // Start is called before the first frame update
    void Start()
    {

        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cerca)
        {
            if (cont == 0)
            {
                if (conejos.tipos == Conejos.Tipos.Naranja)
                {
                    if (player.zanahoria > 0)
                    {
                        player.zanahoria--;
                        //animacion
                        StartCoroutine(Destroy());
                        faltaZanaho = false;
                    }
                    else
                    {
                        faltaZanaho = true;
                    }
                }
                if (conejos.tipos == Conejos.Tipos.Morado)
                {
                    if (player.veterraga > 0)
                    {
                        player.veterraga--;
                        StartCoroutine(Destroy());
                        faltaVeterrag = false;
                    }
                    else
                    {
                        faltaVeterrag = true;
                    }
                }

                if (conejos.tipos == Conejos.Tipos.Amarillo)
                {
                    if (player.kion > 0)
                    {
                        player.kion--;
                        StartCoroutine(Destroy());
                        faltaKion = false;
                    }
                    else
                    {
                        faltaKion = true;
                    }
                }
                if (faltaKion || faltaVeterrag || faltaZanaho)
                {
                    camera.gameObject.SetActive(true);
                    canvas.gameObject.SetActive(true);
                    faltaZanaho = false;
                    faltaVeterrag = false;
                    faltaKion = false;
                }
                cont++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            cerca = true;
            StartCoroutine(Cambio());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cerca = false;
            cont = 0;
        }
    }
    IEnumerator Cambio()
    {
        yield return new WaitForSeconds(duracion);
        camera.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);


    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destruccion);
        Destroy(gameObject);
    }
}

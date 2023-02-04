using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCount : MonoBehaviour
{
    public int count;
    GameObject playerObject;
    Player player;
    public int countMax;
    public float timerMax;
    public float time;
    public GameObject barra;
    public bool paso;
    public bool init;
    [SerializeField]
    public bool atrasPaso;
    // Start is called before the first frame update
    void Start()
    {
        paso = false;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (init)
        {
            time += 1 * Time.deltaTime;
            if (count >= countMax && time < timerMax)
            {
                paso = true;
                count = 0;
                time = 0;
                init = false;
            }
            if (time >= timerMax && count < countMax)
            {
                paso = false;
                count = 0;
                time = 0;
                init = false;atrasPaso = true;
            }
        }
    }

    public void Count()
    {
        if (count < countMax && time < timerMax && init)
        {
            count++;
            barra.transform.localScale += new Vector3(0.1f, 0, 0);
            player.tierra.transform.localScale -= new Vector3(0, 0, 0.3f);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    player pl;
    public Image img;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.isDead == true)
        {
          //  img.enabled = true;
            Button.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public Text Day;
    public float timer;
    public int day = 1;
    // Start is called before the first frame update
    void Start()
    {
        Day = GetComponent<Text>() as Text;
        timer = 0.0f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer += Time.deltaTime / 15;
       
       if(timer >= 24f)
        {
            day += 1;
            timer = 0;
        }

        Day.text = day.ToString("##");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnlarger : MonoBehaviour
{

    Text g;
    public Bobot b;
    int size = 0;
    void Start()
    {
        g = GetComponent<Text>();
        //b = GetComponent<Bobot>();
        g.fontSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (g.fontSize < 100)
            g.fontSize++;
        else
        {
            int gametime = (int)Time.time;
            g.text = gametime.ToString();
            if (gametime > 15)
            {
                b.enabled = false;
                if (b.finishedBuild)
                {
                    g.text = "Dozer is finally happy...";
                    //enabled = false;
                    Dance();
                }
                else
                {
                    g.text = "You lose! Dozer is sad :(";
                    enabled = false;
                }
            }
        }
    }

    void Dance()
    {
        print("in dance()");
        //while (!Input.anyKeyDown)
        //{
            print("in while loop");
            //for (int i = 0; i < 360; i++)
            //{
                print("in for loop");
                b.transform.Rotate(0, size, 0);
        size++;
            //}
        //}
    }
}

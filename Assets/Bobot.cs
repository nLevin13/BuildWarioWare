﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random

public class Bobot : MonoBehaviour {

    public GameObject[] sprites;
    //double[,] finalCoords = new double[,]
    //    {{0.237504,-13.84963},{6.537504,-16.84963},
    //        {12.5375,-11.64963},{2.837504,-15.34963},
    //        {-4.662496,-18.14963}};
    double[,] relative = new double[,]
        {{0,0},{6.3,-3},{12.3,2.2},{2.6,-1.5},{-4.9,-4.3}};
    const float zee = 0.2596754f;
    double cx,xpos;
    double cy,ypos;
    //int[] np = new int[] { -1, 1 };
    int selected = 0;
    float weight = 0.5f;
    public bool finishedBuild = false;

    void Start () {
        GameObject chassis = sprites[0];
        foreach (GameObject g in sprites){
            Random r = new Random();
            g.transform.Translate(Random.Range(-50f,50f),Random.Range(0f,25f),0);
        }
        //chassis.transform.Translate(-10, 0, 0.2596754f);
	}
	
	// Update is called once per frame
	void Update () {
        if (selected < 5)
        {
            
            if (Input.GetKey("right"))
                sprites[selected].transform.Translate(weight, 0, 0);
            if (Input.GetKey("left"))
                sprites[selected].transform.Translate(-weight, 0, 0);
            if (Input.GetKey("up"))
                sprites[selected].transform.Translate(0, weight, 0);
            if (Input.GetKey("down"))
                sprites[selected].transform.Translate(0, -weight, 0);

            //print(sprites[selected].transform.position);

            if (Input.GetKey("q"))
            {
                ypos = sprites[selected].transform.position.y;
                xpos = sprites[selected].transform.position.x;
                if (selected == 0 && FirstInRange())
                {
                    selected++;
                    cx = sprites[0].transform.position.x;
                    cy = sprites[0].transform.position.y;
                }
                else if (selected < 5 && WithinRange(xpos - cx, ypos - cy))
                    selected++;
            }
        }
        else
            finishedBuild = true;
        //print(selected);
    }

    bool FirstInRange()
    {
        double ypos = sprites[0].transform.position.y;
        bool below = ypos > -12;
        bool above = ypos < 0;
        return below && above;
    }

    bool WithinRange(double x, double y)
    {
        int threshold = 3;
        float xdiff = (float)(x-relative[selected,0]);
        float ydiff = (float)(y-relative[selected,1]);
        if(Mathf.Abs(xdiff) < threshold && Mathf.Abs(ydiff) < threshold)
        {
            float xtrans = (float)cx + (float)relative[selected, 0] - (float)xpos;
            float ytrans = (float)cy + (float)relative[selected, 1] - (float)ypos;
            sprites[selected].transform.Translate(xtrans, ytrans, 0);
            return true;
        }
        return false;
    }
}

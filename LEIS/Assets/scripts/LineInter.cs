using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInter : MonoBehaviour
{

    [SerializeField] LineRenderer line1;

    LineRenderer lr;
    Vector3 lrStart;
    Vector3 lrEnd;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        lrStart = lr.GetPosition(0);
        lrEnd = lr.GetPosition(1);

        lr.startColor = Color.black;
        lr.endColor = Color.black;

        //line1.startColor = Color.black;
        //line1.endColor = Color.black;

        if ((FasterLineSegmentIntersection(lrStart, lrEnd, line1.GetPosition(0), line1.GetPosition(1))) ||
            (FasterLineSegmentIntersection(line1.GetPosition(0), line1.GetPosition(1), lrStart, lrEnd)))
        {
            lr.startColor = Color.red;
            lr.endColor = Color.red;
            //line1.startColor = Color.red;
            //line1.endColor = Color.red;
            //Debug.Log("Las lineas se cruzan");
            //Debug.Log("la linea " + lr.name);  
        }

    
    }

    //void onMouseUp()
    //{
    //    Debug.Log("onMouseUp");
    //    if (FasterLineSegmentIntersection(line1.GetPosition(0), lrStart, line1.GetPosition(1), lrEnd))
    //    {
    //        lr.startColor = Color.red;
    //        lr.endColor = Color.red;
    //        Debug.Log("Las lineas se cruzan");
    //        line1.startColor = Color.red;
    //        line1.endColor = Color.red;
    //        Debug.Log("las lineas" + lr.name);
    //    }
    //    else
    //    {
    //        lr.startColor = Color.black;
    //        lr.endColor = Color.black;
    //        line1.startColor = Color.black;
    //        line1.endColor = Color.black;
    //    }
    //}

    static bool FasterLineSegmentIntersection(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {

        Vector2 a = p2 - p1;
        Vector2 b = p3 - p4;
        Vector2 c = p1 - p3;

        float alphaNumerator = b.y * c.x - b.x * c.y;
        float alphaDenominator = a.y * b.x - a.x * b.y;
        float betaNumerator = a.x * c.y - a.y * c.x;
        float betaDenominator = a.y * b.x - a.x * b.y;

        bool doIntersect = true;


        if (alphaDenominator == 0 || betaDenominator == 0)
        {
            doIntersect = false;
            Debug.Log("false 1");
        }
        else
        {

            if (alphaDenominator > 0)
            {
                if (alphaNumerator < 0 || alphaNumerator > alphaDenominator)
                {
                    doIntersect = false;
                    Debug.Log("false 2");

                }
            }
            else if (alphaNumerator > 0 || alphaNumerator < alphaDenominator)
            {
                doIntersect = false;
                Debug.Log("false 3");
            }

            if (/*doIntersect*/ betaDenominator > 0)

                if (betaNumerator < 0 || betaNumerator > betaDenominator)
                {
                    doIntersect = false;
                    Debug.Log("false 4");
                }
                else if (betaNumerator > 0 || betaNumerator < betaDenominator)
                {
                    doIntersect = false;
                    Debug.Log("false 5");
                }
        }

        return doIntersect;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUp : MonoBehaviour {

    [SerializeField] LineRenderer myLine;
    [SerializeField] LineRenderer conectedLine;
    [SerializeField] LineRenderer intersectLine;
    [SerializeField] LineRenderer conectedInsersect;

    private void OnMouseUp()
    {
        Debug.Log("onMouseUp");

        if (FasterLineSegmentIntersection(myLine.GetPosition(0), myLine.GetPosition(1), intersectLine.GetPosition(0), intersectLine.GetPosition(1)))
        {
            if (LineIntersect(myLine.GetPosition(0), myLine.GetPosition(1), intersectLine.GetPosition(0), intersectLine.GetPosition(1)))
            {

                myLine.startColor = Color.red;
                myLine.endColor = Color.red;

                intersectLine.startColor = Color.red;
                intersectLine.endColor = Color.red;
            }
        }
        else
        {
            if (FasterLineSegmentIntersection(conectedLine.GetPosition(0), conectedLine.GetPosition(1), conectedInsersect.GetPosition(0), conectedInsersect.GetPosition(1)))
            {
                if (LineIntersect(conectedLine.GetPosition(0), conectedLine.GetPosition(1), conectedInsersect.GetPosition(0), conectedInsersect.GetPosition(1)))
                {


                    conectedLine.startColor = Color.red;
                    conectedLine.endColor = Color.red;

                    conectedInsersect.startColor = Color.red;
                    conectedInsersect.endColor = Color.red;
                }
            }
            else
            {
                if (FasterLineSegmentIntersection(intersectLine.GetPosition(0), intersectLine.GetPosition(1), myLine.GetPosition(0), myLine.GetPosition(1)))
                {
                    if (LineIntersect(intersectLine.GetPosition(0), intersectLine.GetPosition(1), myLine.GetPosition(0), myLine.GetPosition(1)))
                    {


                        myLine.startColor = Color.red;
                        myLine.endColor = Color.red;

                        intersectLine.startColor = Color.red;
                        intersectLine.endColor = Color.red;
                    }
                }
                else
                {
                    if (FasterLineSegmentIntersection(conectedInsersect.GetPosition(0), conectedInsersect.GetPosition(1), conectedLine.GetPosition(0), conectedLine.GetPosition(1)))
                    {
                        if (LineIntersect(conectedInsersect.GetPosition(0), conectedInsersect.GetPosition(1), conectedLine.GetPosition(0), conectedLine.GetPosition(1)))
                        {

                            conectedLine.startColor = Color.red;
                            conectedLine.endColor = Color.red;

                            conectedInsersect.startColor = Color.red;
                            conectedInsersect.endColor = Color.red;
                        }
                        else
                        {

                            conectedLine.startColor = Color.black;
                            conectedLine.endColor = Color.black;
                            conectedInsersect.startColor = Color.black;
                            conectedInsersect.endColor = Color.black;

                            myLine.startColor = Color.black;
                            myLine.endColor = Color.black;
                            intersectLine.startColor = Color.black;
                            intersectLine.endColor = Color.black;
                        }
                    }
                    else
                    {

                        conectedLine.startColor = Color.black;
                        conectedLine.endColor = Color.black;
                        conectedInsersect.startColor = Color.black;
                        conectedInsersect.endColor = Color.black;

                        myLine.startColor = Color.black;
                        myLine.endColor = Color.black;
                        intersectLine.startColor = Color.black;
                        intersectLine.endColor = Color.black;
                    }
                }
            }
        }



    }


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

        }
        else
        {

            if (alphaDenominator > 0)
            {
                if (alphaNumerator < 0 || alphaNumerator > alphaDenominator)
                {
                    doIntersect = false;


                }
            }
            else if (alphaNumerator > 0 || alphaNumerator < alphaDenominator)
            {
                doIntersect = false;

            }

            if (/*doIntersect*/ betaDenominator > 0)

                if (betaNumerator < 0 || betaNumerator > betaDenominator)
                {
                    doIntersect = false;

                }
                else if (betaNumerator > 0 || betaNumerator < betaDenominator)
                {
                    doIntersect = false;

                }
        }

        return doIntersect;
    }

    static bool LineIntersect(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        float x;
        float y;
        float numX;
        float numY;
        bool intersect = false;

        Vector2 a = p2 - p1;
        Vector2 b = p3 - p4;
        Vector2 c = p1 - p3;

        float alphaNumerator = b.y * c.x - b.x * c.y;
        float bothDenominator = a.y * b.x - a.x * b.y;
        // compute intersection coordinates //

        numX = alphaNumerator * a.x; // numerator //

        x = p1.x + numX / bothDenominator;

        numY = alphaNumerator * a.y;

        y = p1.y + numY / bothDenominator;





        if (((p1.x < x && p2.x > x) || (p1.y < y && p2.y > y)) ||
            ((p1.x > x && p2.x < x) || (p1.y > y && p2.y < y)))
        {
            if (((p3.x < x && p4.x > x) || (p3.y < y && p4.y > y)) ||
            ((p3.x > x && p4.x < x) || (p3.y > y && p4.y < y)))
            {
                intersect = true;
            }
        }

        return intersect;
    }
}


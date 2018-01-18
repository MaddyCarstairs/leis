using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUp2Intersect : MonoBehaviour {

    [SerializeField] LineRenderer myLine;
    [SerializeField] LineRenderer conectedLine;
    [SerializeField] LineRenderer intersect1;
    [SerializeField] LineRenderer intersect2;
    [SerializeField] LineRenderer otherLine;


    private void OnMouseUp()
    {
        Debug.Log("onMouseUp");

        if (FasterLineSegmentIntersection(myLine.GetPosition(0), myLine.GetPosition(1), intersect1.GetPosition(0), intersect1.GetPosition(1))) //1 - 3
        {
            ColorIntersect(myLine, intersect1);
            Debug.Log("1-3");
        }
        else
        {
            if (FasterLineSegmentIntersection(myLine.GetPosition(0), myLine.GetPosition(1), intersect2.GetPosition(0), intersect2.GetPosition(1))) //1 - 4
            {
                ColorIntersect(myLine, intersect2);
                Debug.Log("1-4");
            }
            else
            {
                if (FasterLineSegmentIntersection(otherLine.GetPosition(0), otherLine.GetPosition(1), intersect2.GetPosition(0), intersect2.GetPosition(1))) //2 - 4
                {
                    ColorIntersect(otherLine, intersect2);
                    Debug.Log("2-4");
                }
                else
                {
                    if (FasterLineSegmentIntersection(otherLine.GetPosition(0), otherLine.GetPosition(1), conectedLine.GetPosition(0), conectedLine.GetPosition(1))) //2-5
                    {
                        ColorIntersect(otherLine, conectedLine);
                        Debug.Log("2-5");
                    }
                    else
                    {
                        if (FasterLineSegmentIntersection(intersect1.GetPosition(0), intersect1.GetPosition(1), conectedLine.GetPosition(0), conectedLine.GetPosition(1)))//3-5
                        {
                            ColorIntersect(intersect1, conectedLine);
                            Debug.Log("3-5");
                        }
                        else
                        {
                            if (FasterLineSegmentIntersection(intersect1.GetPosition(0), intersect1.GetPosition(1), myLine.GetPosition(0), myLine.GetPosition(1)))  //3-1
                            {
                                ColorIntersect(intersect1, myLine);
                                Debug.Log("3-1");
                            }
                            else
                            {
                                if (FasterLineSegmentIntersection(intersect2.GetPosition(0), intersect2.GetPosition(1), myLine.GetPosition(0), myLine.GetPosition(1)))//4-1
                                {
                                    ColorIntersect(intersect2, myLine);
                                    Debug.Log("1-3");
                                }
                                else
                                {
                                    if (FasterLineSegmentIntersection(intersect2.GetPosition(0), intersect2.GetPosition(1), otherLine.GetPosition(0), otherLine.GetPosition(1)))//4-2
                                    {
                                        ColorIntersect(intersect2, otherLine);
                                    }
                                    else
                                    {
                                        if (FasterLineSegmentIntersection(conectedLine.GetPosition(0), conectedLine.GetPosition(1), otherLine.GetPosition(0), otherLine.GetPosition(1)))//5-2
                                        {
                                            ColorIntersect(conectedLine, otherLine);
                                        }
                                        else
                                        {
                                            if (FasterLineSegmentIntersection(conectedLine.GetPosition(0), conectedLine.GetPosition(1), intersect1.GetPosition(0), intersect1.GetPosition(1)))//5-3
                                            {
                                                if (LineIntersect(conectedLine.GetPosition(0), conectedLine.GetPosition(1), intersect1.GetPosition(0), intersect1.GetPosition(1)))
                                                {
                                                    conectedLine.startColor = Color.red;
                                                    conectedLine.endColor = Color.red;

                                                    intersect1.startColor = Color.red;
                                                    intersect1.endColor = Color.red;
                                                }
                                                else
                                                {
                                                    myLine.startColor = Color.black;
                                                    myLine.endColor = Color.black;

                                                    conectedLine.startColor = Color.black;
                                                    conectedLine.endColor = Color.black;

                                                    intersect1.startColor = Color.black;
                                                    intersect1.endColor = Color.black;

                                                    intersect2.startColor = Color.black;
                                                    intersect2.endColor = Color.black;

                                                    otherLine.startColor = Color.black;
                                                    otherLine.endColor = Color.black;
                                                }
                                            }
                                            else
                                            {
                                                myLine.startColor = Color.black;
                                                myLine.endColor = Color.black;

                                                conectedLine.startColor = Color.black;
                                                conectedLine.endColor = Color.black;

                                                intersect1.startColor = Color.black;
                                                intersect1.endColor = Color.black;

                                                intersect2.startColor = Color.black;
                                                intersect2.endColor = Color.black;

                                                otherLine.startColor = Color.black;
                                                otherLine.endColor = Color.black;
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
    static void ColorIntersect(LineRenderer line1, LineRenderer line2)
    {
        if (LineIntersect(line1.GetPosition(0), line1.GetPosition(1), line2.GetPosition(0), line2.GetPosition(1)))
        {

            line1.startColor = Color.red;
            line1.endColor = Color.red;

            line2.startColor = Color.red;
            line2.endColor = Color.red;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2oposites : MonoBehaviour {

    [SerializeField] GameObject moveBall;
    [SerializeField] GameObject conectecBall;
    [SerializeField] LineRenderer opositeLine;
    [SerializeField] LineRenderer opositeLine2;


    private LineRenderer lr;
    private BoxCollider2D bc;


    Transform lineStart;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));

        // Set some positions
        Vector3[] positions = new Vector3[2];
        positions[0] = moveBall.transform.position;
        positions[1] = conectecBall.transform.position;

        lr.positionCount = positions.Length;
        lr.SetPositions(positions);

        lr.startColor = Color.black;
        lr.endColor = Color.black;

        if ((FasterLineSegmentIntersection(lr.GetPosition(0), lr.GetPosition(1), opositeLine.GetPosition(0), opositeLine.GetPosition(1)))
           || (FasterLineSegmentIntersection(opositeLine.GetPosition(0), opositeLine.GetPosition(1), lr.GetPosition(0), lr.GetPosition(1))))
        {
            lr.startColor = Color.red;
            lr.endColor = Color.red;

            opositeLine.startColor = Color.red;
            opositeLine.endColor = Color.red;

        }

        if ((FasterLineSegmentIntersection(lr.GetPosition(0), lr.GetPosition(1), opositeLine2.GetPosition(0), opositeLine2.GetPosition(1)))
          || (FasterLineSegmentIntersection(opositeLine2.GetPosition(0), opositeLine2.GetPosition(1), lr.GetPosition(0), lr.GetPosition(1))))
        {

            opositeLine2.startColor = Color.red;
            opositeLine2.endColor = Color.red;

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
}

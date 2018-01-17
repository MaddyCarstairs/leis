using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class line : MonoBehaviour
{

    [SerializeField] GameObject moveBall;
    [SerializeField] GameObject conectecBall;
    [SerializeField] LineRenderer opositeLine;

    private LineRenderer lr;
    private BoxCollider2D bc;

    Vector3 lrStart;
    Vector3 lrEnd;

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


        if ((FasterLineSegmentIntersection(lr.GetPosition(0), lr.GetPosition(1), opositeLine.GetPosition(0), opositeLine.GetPosition(1))) ||
            (FasterLineSegmentIntersection(opositeLine.GetPosition(0), opositeLine.GetPosition(1), lr.GetPosition(0), lr.GetPosition(1))))
        {
            lr.startColor = Color.red;
            lr.endColor = Color.red;
        }
        else
        {
            lr.startColor = Color.black;
            lr.endColor = Color.black;
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

    //private void Update()
    //{
    //   BoxCollider2D bc = lr.GetComponentInChildren<BoxCollider2D>();

    //    float lineLength = Vector3.Distance(lr.GetPosition(0), lr.GetPosition(1)); // length of line
    //    bc.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
    //    Vector3 midPoint = (lr.GetPosition(0) + lr.GetPosition(1)) / 2;
    //    bc.transform.position = midPoint; // setting position of collider object
    //                                       // Following lines calculate the angle between startPos and endPos


    //    float angle = (Mathf.Abs(lr.GetPosition(0).y - lr.GetPosition(1).y) / Mathf.Abs(lr.GetPosition(0).x - lr.GetPosition(1).x));
    //    if ((lr.GetPosition(0).y < lr.GetPosition(1).y && lr.GetPosition(0).x > lr.GetPosition(1).x) || (lr.GetPosition(1).y < lr.GetPosition(0).y && lr.GetPosition(1).x > lr.GetPosition(0).x))
    //    {
    //        angle *= -1;
    //    }
    //    angle = Mathf.Rad2Deg * Mathf.Atan(angle);
    //    bc.transform.Rotate(0, 0, angle);
    //}

    //// Following method adds collider to created line
    //private void addColliderToLine()
    //{
    //    BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D>();
    //    col.transform.parent = lr.transform; // Collider is added as child object of line

    //    float lineLength = Vector3.Distance(lr.GetPosition(0), lr.GetPosition(1)); // length of line
    //    col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
    //    Vector3 midPoint = (lr.GetPosition(0) + lr.GetPosition(1)) / 2;
    //    col.transform.position = midPoint; // setting position of collider object
    //                                       // Following lines calculate the angle between startPos and endPos
    //    float angle = (Mathf.Abs(lr.GetPosition(0).y - lr.GetPosition(1).y) / Mathf.Abs(lr.GetPosition(0).x - lr.GetPosition(1).x));
    //    if ((lr.GetPosition(0).y < lr.GetPosition(1).y && lr.GetPosition(0).x > lr.GetPosition(1).x) || (lr.GetPosition(1).y < lr.GetPosition(0).y && lr.GetPosition(1).x > lr.GetPosition(0).x))
    //    {
    //        angle *= -1;
    //    }
    //    angle = Mathf.Rad2Deg * Mathf.Atan(angle);
    //    col.transform.Rotate(0, 0, angle);
    //}
    //Ray
    //RaycastHit hit;

    //private void Update()
    //{



    //    if (Physics.Raycast(lr.GetPosition(0), lr.GetPosition(1), out hit))
    //    {
    //        switch (hit.transform.gameObject.tag)
    //        {
    //            case "line":
    //                //Output message
    //                print("line touch");
    //                break;
    //        }
    //    }
    //}
}

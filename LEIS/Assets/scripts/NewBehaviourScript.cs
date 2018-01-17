using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Texture2D punteroTexture;
    public Texture2D marcarTexture;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    //// Use this for initialization
    //void Start()
    //{
    //    Cursor.SetCursor(punteroTexture, hotSpot, curMode);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void OnMouseEnter()
    //{
      
    //    if(gameObject.tag == "Ponerdedo")
    //    {
            
    //        Cursor.SetCursor(marcarTexture, hotSpot, curMode);
            
    //    }
    //}
    //void OnMouseExit()
    //{
        
    //    Cursor.SetCursor(punteroTexture, hotSpot, curMode);
    //}

     public void Hola()
    {
        Cursor.SetCursor(marcarTexture, hotSpot, curMode);
    }
    public void Adios()
    {
        Cursor.SetCursor(punteroTexture, hotSpot, curMode);
    }

}

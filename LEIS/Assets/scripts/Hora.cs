using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hora : MonoBehaviour {

    public Text currentTime;
	void Update () {
        currentTime.text =
            System.DateTime.Now.Hour.ToString("00") + ":" +
            System.DateTime.Now.Minute.ToString("00 ")+
            System.DateTime.Now.Date.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class Show_Info : MonoBehaviour
{
    public Text TextBlock;
    public string info;
    private void Start() {
        Debug.Log("Start");
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextBlock.text = info;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClick : MonoBehaviour
{
    public int id;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        NetworkedClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.Pop:D},{id}");
    }
}

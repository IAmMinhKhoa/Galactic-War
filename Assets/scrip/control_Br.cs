using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_Br : MonoBehaviour
{
    // Start is called before the first frame update
    float scrollspeed=-5f;
    Vector2 brpos;
  //  public Camera cmr;
    void Start()
    {
        brpos =transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newpos=Mathf.Repeat(Time.time*scrollspeed,21.86f );
        transform.position =brpos+ Vector2.right*newpos;
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_hero_boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float smoth=3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>=6f)
        {
            float x=transform.position.x;
            x-=Time.smoothDeltaTime/smoth;
            transform.position=new Vector2(x,transform.position.y);
        }
    }
}

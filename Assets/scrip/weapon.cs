using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletprefab;
    
    public float Time_delay;

    float temp1;
        void Start()
    {
        temp1=Time_delay;
    }

    // Update is called once per frame
    void Update()
    {
        temp1-=Time.smoothDeltaTime;
        if(temp1<0)
        {
                shoot();
                temp1=Time_delay;
        }


    }
    void shoot()
    {
        Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
    }
}

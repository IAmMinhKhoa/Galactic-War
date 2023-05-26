using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_boos : MonoBehaviour
{
    // Start is called before the first frame update
     public Transform firepoint;
    public GameObject bulletprefab;
   public float spawm_bullet=0.5f;
   float temp;
    void Start()
    {
        temp=spawm_bullet;
    }

    // Update is called once per frame
    void Update()
    {
        spawm_bullet-=Time.deltaTime;
        if(spawm_bullet<0)
        {
            Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
            spawm_bullet=temp;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed_1;//công dụng làm tốc độ cho bullet sau khi het timeslow
    public float speed_2;//cong dụng làm tốc độ trong timeslow
    public float direc; 
    public GameObject explo;
    public float timeSlow=2f;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
       timeSlow-=Time.smoothDeltaTime;
     
       if(timeSlow<0)
       {
            rb.velocity =-(direc*transform.up+transform.right)*speed_1;
          
       }
       else if( timeSlow>0)
       {
            rb.velocity =-(direc*transform.up+transform.right)*speed_2;
       }
        
     
    }
    
      void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="bullet"||other.gameObject.tag=="ship")
        {
          GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
           Destroy(this.gameObject);
            Destroy(effect,0.5f);
        }
        if(other.gameObject.tag =="Limit" )
        {
            Destroy(this.gameObject);
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag=="Shield_Ship" )
        {
          GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
           Destroy(this.gameObject);
            Destroy(effect,0.5f);
        }
    }
}

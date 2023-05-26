using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=20f;
     public GameObject explo;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right*speed;
    }
      void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="enemy"|| other.gameObject.tag=="Boss")
        {
          GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
           Destroy(this.gameObject);
            Destroy(effect,0.5f);
        }
        if( other.gameObject.tag =="bullet_boss"  )
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="shield" ||other.gameObject.tag =="Limit")
        {
            GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
            Destroy(this.gameObject);
            Destroy(effect,0.5f);
        }
    }
}

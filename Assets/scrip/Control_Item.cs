using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Item : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed=1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity =new Vector2(-speed,transform.position.y);
        rb.rotation +=0.25f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="ship"||other.gameObject.tag=="Limit")
        {
            Destroy(this.gameObject);
        }
    }
}

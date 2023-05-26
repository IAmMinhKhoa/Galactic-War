using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_enemy : MonoBehaviour
{
    int health=200;
    private Rigidbody2D rb;
    public float X_enemy=1f;
    public float Y_enemy=1f;
    public GameObject explo;
    Manager_Score M_Score;
    SpriteRenderer Sprite;
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
      M_Score =FindObjectOfType<Manager_Score>();
       Sprite =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity= new Vector2(X_enemy,Y_enemy);
        rb.rotation +=0.25f;
        X_enemy+=X_enemy*Time.smoothDeltaTime/1.5f;
        if(X_enemy>=10)
        {
            X_enemy=9;
        }
    }
    void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Limit"||other.gameObject.tag=="ship")
        {
            
            GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
            Destroy(this.gameObject);
            Destroy(effect,0.5f);
          
        }
        if(other.gameObject.tag=="bullet")
        {
            health-=100;
            StartCoroutine(Effect_Death(1,0,0,1));
            if(health<=0)
            {
                M_Score.score+=100;
                Destroy(this.gameObject);
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Shield_Ship" ||other.gameObject.tag=="Until_ship_2")
        {
            GameObject effect = Instantiate(explo,transform.position,Quaternion.identity);  //BẮT ĐẦU XUẤT HIỆN HIỆU ỨNG NỔ
            Destroy(this.gameObject);
            Destroy(effect,0.5f);
        }
    }

    IEnumerator Effect_Death(float color1,float color2,float color3,float color4)
    {
        Sprite.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.5f);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.5f);
        Sprite.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.5f);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.5f);
        Sprite.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.5f);
        Sprite.color =new Color(1f,1f,1f,1f);
    }

      
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float time_spawn_laser=1f;

    public float time_Blaming=1f;
    SpriteRenderer Sprite;// dùng đề lấy sprite ảnh ship cho nhấp nahy1 warning
    public GameObject Until_miniBoss;
    float temp1;
     float temp2;
     //HEALTH
     public float health=2000;
    void Start()
    {
        temp1= time_spawn_laser;
        temp2= time_Blaming;
    }

    // Update is called once per frame
    void Update()
    {
        time_spawn_laser-=Time.deltaTime;// Sau mỗi timespawmlaser thì tiến hành warning+bắn 1 lần
    if(time_spawn_laser<0)  //khi đến time warning +bắn
    {
        time_Blaming-=Time.deltaTime;
        Until_miniBoss.SetActive(true);
       
            if(time_Blaming<0) //khi hết time bắn
            {
                Until_miniBoss.SetActive(false); //set false dừng lại blame
                //và setup lại time các tiến trình
                time_spawn_laser=temp1;
                time_Blaming=temp2;
              
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="bullet")
        {
            health-=100;
            if(health<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="shield")
        {
            health-=100;
            if(health<=0)
            {
                Destroy(this.gameObject);
            }
    
        }
    }
}

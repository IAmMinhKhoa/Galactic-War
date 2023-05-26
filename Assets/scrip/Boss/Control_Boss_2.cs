using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Control_Boss_2 : MonoBehaviour
{
    public int health_boss=1000;
    private Rigidbody2D rb;
    float BossPos;
    bool checkUpDown;
    public float pos_x_max;//Vị trí tối đá bên trái ma boss chạm tới
    public float pos_y_max;
    public GameObject Until_Boss_2;
    SpriteRenderer Sprite;// dùng đề lấy sprite ảnh ship cho nhấp nahy1 warning
    int color_ship=0; //mau2 cho ship nhấp nháy
    public float time_spawn_laser=5f;
    float temp1;
 
     //CÁC VỊ TRÍ VÀ ANIMATION KHI BOSS NỔ
    public Transform Point_Explo_1;
    public Transform Point_Explo_2;
    public Transform Point_Explo_3;
    public GameObject Explo;
    //TANG DIEM KHI DIET BOSS
    Manager_Score M_Score;
        //LẤY BR ĐỂ CHANGE MÀU
    public SpriteRenderer Br1;
    public SpriteRenderer Br2;
    public GameObject Health_bar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        temp1=time_spawn_laser;
        M_Score =FindObjectOfType<Manager_Score>();
        Br1.color =new Color(1f,0f,1f,1f);
        Br2.color =new Color(1f,0f,1f,1f);

    }
    bool check_blame_laser=true;
    // Update is called once per frame
    void Update()
    {
        // AUTO MOVE    
        if(transform.position.x<=pos_x_max)
        {
                if(checkUpDown==true)
                {
                    BossPos =transform.position.y+1f*Time.deltaTime;
                    transform.position = new Vector2(pos_x_max,BossPos);
                    if(transform.position.y>=pos_y_max)
                    {
                        checkUpDown=false;
                    }
                }
                else if(checkUpDown==false)
                {
                    BossPos =transform.position.y-1f*Time.deltaTime;
                    transform.position = new Vector2(pos_x_max,BossPos);
                if(transform.position.y<=-pos_y_max)
                    {
                        checkUpDown=true;
                    }
                }
                else{
                    BossPos =transform.position.y+1f*Time.deltaTime;
                    transform.position = new Vector2(pos_x_max,BossPos);
                    checkUpDown=false;
                }
        }else 
        {
            rb.velocity =-transform.right*Time.deltaTime*999;
        }
    
      
    //SETUP BẮN BLAME LASER
    time_spawn_laser-=Time.deltaTime;// Sau mỗi timespawmlaser thì tiến hành warning+bắn 1 lần
    if(time_spawn_laser<0)  //khi đến time warning +bắn
    {
         StartCoroutine(OnOffUntil(0.3f,4));
         time_spawn_laser=temp1;
    }
      IEnumerator OnOffUntil(float time1,float time2)
    {
        //tiến hành waning
        Sprite.color =new Color(0f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(0f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(0f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        //TIẾN HÀNH BẮN UNTIL
        Until_Boss_2.SetActive(true);  //set true cho gameojb blame chạy
        yield return new WaitForSeconds(time2);
        Until_Boss_2.SetActive(false);

      
    }
 

    }

       void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="bullet")
        {
           health_boss-=100;
           Health_bar.GetComponentInChildren<Slider>().value-=100;
           if(health_boss==0)
           {
               Destroy(this.gameObject);
                GameObject effect_1 = Instantiate(Explo,Point_Explo_1.position,Quaternion.identity);
                GameObject effect_2 = Instantiate(Explo,Point_Explo_2.position,Quaternion.identity);
                GameObject effect_3 = Instantiate(Explo,Point_Explo_3.position,Quaternion.identity);  
                Destroy(effect_1,1f);
                Destroy(effect_2,1f);
                Destroy(effect_3,1f);
                M_Score.score+=10000;
           }
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Shield_Ship")
        {
            health_boss-=100;
            Health_bar.GetComponentInChildren<Slider>().value-=100;
            StartCoroutine(Effect_dame(1,1,0,1));
             if(health_boss<0)
           {
                Br1.color =new Color(1f,1f,1f,1f);
                Br2.color =new Color(1f,1f,1f,1f);
                Destroy(this.gameObject);
                GameObject effect_1 = Instantiate(Explo,Point_Explo_1.position,Quaternion.identity);
                GameObject effect_2 = Instantiate(Explo,Point_Explo_2.position,Quaternion.identity);
                GameObject effect_3 = Instantiate(Explo,Point_Explo_3.position,Quaternion.identity);  
                Destroy(effect_1,1f);
                Destroy(effect_2,1f);
                Destroy(effect_3,1f);
                M_Score.score+=10000; //tăng điểm
           }
        }
    }
        IEnumerator Effect_dame(float color1,float color2,float color3,float color4)
    {
        Sprite.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.2f);
        Sprite.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite.color =new Color(1f,1f,1f,1f);
    }
  



}


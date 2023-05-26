using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Control_Boss_3 : MonoBehaviour
{
     public int health_boss=1000;
    private Rigidbody2D rb;
    //CÁC BIẾN di chuyển auto boss
    float BossPos;
    bool checkUpDown;
    public float pos_x_max;//Vị trí tối đá bên trái ma boss chạm tới
    public float pos_x_max_miniboss;
    public float pos_y_max;
    //TIẾN HÀNH CẢNH BÁO VÀ BẮN LASER MEGA
    int color_ship=0; //mau2 cho ship nhấp nháy
    public float time_spawn_laser=5f;

    SpriteRenderer Sprite;// dùng đề lấy sprite ảnh ship cho nhấp nahy1 warning
    public GameObject Until_Boss_3;
    float temp1;

    //lấy các sprite br
    public SpriteRenderer Br1;
    public SpriteRenderer Br2;
    //tiến hành bật shield
    public GameObject Shield;
    public float time_spawn_shield=5f;
    public float time_shield=5f;
    float temp4;
    float temp5;
    //3 MINI BOSS PHÍA TRƯỚC
    public GameObject Mini1;
    public GameObject Mini2;
    public GameObject Mini3;
    public float move;

    //CÁC GAMEPJB WEAPON CỦA BOSS 3
    public weapon_boos weapon_1;
    public weapon_boos weapon_2;
    public weapon_boos weapon_3;
    public weapon_boos weapon_4;
     //CÁC VỊ TRÍ VÀ ANIMATION KHI BOSS NỔ
    public Transform Point_Explo_1;
    public Transform Point_Explo_2;
    public Transform Point_Explo_3;
    public GameObject Explo;
    //TANG DIEM KHI DIET BOSS
       Manager_Score M_Score;
 public GameObject Health_bar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
         temp1=time_spawn_laser;
       
         Br1.color =new Color(1f,0f,0f,1f);
         Br2.color =new Color(1f,0f,0f,1f);
         temp4 =time_spawn_shield;
         temp5 =time_shield;
         move=rb.transform.position.x;
            M_Score =FindObjectOfType<Manager_Score>();
  
       
    }

    // Update is called once per frame
    void Update()
    {
    if(Mini1==null && Mini2==null && Mini3==null)
    {
        if(transform.position.x<=pos_x_max)
        {      Shield.SetActive(false);
                weapon_1.enabled=true;
                weapon_2.enabled=true;
                weapon_3.enabled=true;
                weapon_4.enabled=true;
                if(checkUpDown==true)
                {
                    BossPos =transform.position.y+1.6f*Time.deltaTime;
                    transform.position = new Vector2(pos_x_max,BossPos);
                    if(transform.position.y>=pos_y_max)
                    {
                        checkUpDown=false;
                    }
                }
                else if(checkUpDown==false)
                {
                    BossPos =transform.position.y-1.6f*Time.deltaTime;
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
    time_spawn_laser-=Time.deltaTime;// Sau mỗi timespawmlaser thì tiến hành warning+bắn 1 lần
    if(time_spawn_laser<0)  //khi đến time warning +bắn
    {

         StartCoroutine(OnOffUntil(0.3f,3));
         time_spawn_laser=temp1;
    }
    //TIẾN HÀNH KIỂM TRA BẬT SHIELD
    if(health_boss<1900)
    {
        time_spawn_shield-=Time.deltaTime;
        if(time_spawn_shield<0)
        {
            Shield.SetActive(true);
            time_shield-= Time.deltaTime;
            if(time_shield<=0)
            {
                Shield.SetActive(false);
                time_spawn_shield=temp4;
                time_shield=temp5;
            }
        }
    }
    }
    else
    {
        transform.position =new Vector2(move,0.16f);
        move-=Time.smoothDeltaTime;
        if(rb.transform.position.x<=pos_x_max_miniboss)
        {
            transform.position =new Vector2(pos_x_max_miniboss,0.16f);
                  
        }
    }
}
        IEnumerator OnOffUntil(float time1,float time2)
    {
        //tiến hành waning
        Sprite.color =new Color(1f,1f,0f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,0f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,0f,1f);
        yield return new WaitForSeconds(time1);
        Sprite.color =new Color(1f,1f,1f,1f);
        //TIẾN HÀNH BẮN UNTIL
        Until_Boss_3.SetActive(true);  //set true cho gameojb blame chạy
        yield return new WaitForSeconds(time2);
        Until_Boss_3.SetActive(false);
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

       void  OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="bullet")
        {
           health_boss-=100;
           Health_bar.GetComponentInChildren<Slider>().value-=100;
           if(health_boss==0)
           {
               Destroy(this.gameObject);
                Br1.color =new Color(1f,1f,1f,1f);
                Br2.color =new Color(1f,1f,1f,1f);
                GameObject effect_1 = Instantiate(Explo,Point_Explo_1.position,Quaternion.identity);
                GameObject effect_2 = Instantiate(Explo,Point_Explo_2.position,Quaternion.identity);
                GameObject effect_3 = Instantiate(Explo,Point_Explo_3.position,Quaternion.identity);  
                Destroy(effect_1,1f);
                Destroy(effect_2,1f);
                Destroy(effect_3,1f);
                  M_Score.score+=15000;
           }
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Shield_Ship")
        {
            health_boss-=100;
            Health_bar.GetComponentInChildren<Slider>().value-=100;
            StartCoroutine(Effect_dame(0,1,0,1));
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
                M_Score.score+=15000; //tăng điểm
           }
        }
    }
}

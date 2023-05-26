using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Control_Ship : MonoBehaviour
{
   public int health_ship=1000;
   public int Val_Move=10;
   public float Gravity_left=50f;
   public Rigidbody2D rb;
   int temp;
   public GameObject Ship;
   SpriteRenderer Sprite_ship;
   public GameObject shield;
   int level_bullet=0;
   weapon weaponship;
  public int count_shield=0;

        //các chỉ số tốc độ đạn
 public List<float> speed_level;
   public List<GameObject> Point_gun; //lsit vị trí các đạn khi upgrade level
   //LẤY CANVAS VÀO SCRIP
   
   //   BUTTON KHI LEVEL 3_SHIP_2 BẮN RA LASER
    public GameObject bt_fire;
   //KHI CHẠM ITEM SHIELD THI TUREN ON
   public GameObject bt_shield;
   
   public bool check_shield=false;//False là shield đã tắt, true shield là bật 
   public bool check_util=false;//False là until đã tắt, true until là bật 
   float time_until_ship_2=4f;

 public GameObject Text_max_level;
 public Joystick joystick;
 public float max_x;
 public float min_x;
 public float max_y;
 public float min_y;
 public GameObject Health_bar;
    void Start()
    {
        count_shield=PlayerPrefs.GetInt("count_shield");;
        temp=health_ship;  
        Sprite_ship =Ship.GetComponent<SpriteRenderer>();
        weaponship =GetComponent<weapon>();
        weaponship.Time_delay=speed_level[0];
        if(count_shield>0)
        {
                bt_shield.SetActive(true);
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
            
         rb.velocity =-transform.right*Time.smoothDeltaTime*Gravity_left;
        if(joystick.Horizontal>=0.2f)
        {
                Vector3 position = this.transform.position;
                position.x+=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
         if(joystick.Horizontal<=-0.2f)
        {
                  Vector3 position = this.transform.position;
                position.x-=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
        if(joystick.Vertical>=0.2f)
        {
                 Vector3 position = this.transform.position;
                position.y+=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
        if(joystick.Vertical<=-0.2f)
        {
                Vector3 position = this.transform.position;
                position.y-=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }

         if (Input.GetKey(KeyCode.A))
        {
             //   shield.SetActive(true);
                 Vector3 position = this.transform.position;
                position.x-=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //    shield.SetActive(false);
                Vector3 position = this.transform.position;
                position.x+=Time.deltaTime*Val_Move;
                this.transform.position = position;
            
        }
        if (Input.GetKey(KeyCode.W))
        {
                Vector3 position = this.transform.position;
                position.y+=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
                Vector3 position = this.transform.position;
                position.y-=Time.deltaTime*Val_Move;
                this.transform.position = position;
        }
     
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,min_x,max_x),Mathf.Clamp(transform.position.y,min_y,max_y),transform.position.z);
        //tiến hành kiểm tra nếu cont_shield thì ẩn cái button shield
        if(count_shield<=0)
        {
                bt_shield.SetActive(false);
        }else{
                  bt_shield.GetComponentInChildren<Text>().text=count_shield.ToString();
        }

           
    }
      void  OnCollisionEnter2D(Collision2D other)
    {
                if(other.gameObject.tag=="enemy")
                {
                        health_ship-=500;
                        Health_bar.GetComponentInChildren<Slider>().value-=500;
                        if(health_ship<=0)
                        {
                                this.gameObject.SetActive(false);
                        }
                        
                }
                if(other.gameObject.tag=="bullet_boss")
                {
                        health_ship-=100;
                        Health_bar.GetComponentInChildren<Slider>().value-=100;
                        if(health_ship<=0)
                        {
                                this.gameObject.SetActive(false);
                        }
                }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Until")
        {
                health_ship-=500;
                Health_bar.GetComponentInChildren<Slider>().value-=500;
                if(health_ship<=0)
                {
                        Destroy(this.gameObject);
                }
        }
        if(other.gameObject.tag=="item_health")
        {  
                if(health_ship>=temp)
                {
                        StartCoroutine(Warnning_max_level(0.4f,"HP Max"));
                }
                else{
                        Health_bar.GetComponentInChildren<Slider>().value=temp;
                        health_ship=temp;
                        StartCoroutine(Effect_health(0,1,0,1));
                }

        }
        if(other.gameObject.tag=="item_upgrade")
        {  
             if(this.gameObject.name=="Ship_1")
             {
                 StartCoroutine(Effect_upgrade_bullet(1,0,0,1));
                level_bullet+=1;
                if(level_bullet==1)
                {
                        weaponship.Time_delay=speed_level[1];
                }
                if(level_bullet==2)
                {
                        weaponship.Time_delay=speed_level[2];
                }
                if(level_bullet==3)
                {
                        weaponship.Time_delay=speed_level[3];
                        Point_gun[0].SetActive(true);
                        Point_gun[1].SetActive(true);
                      
                }
                if(level_bullet==4)
                {
                        weaponship.Time_delay=speed_level[4];
                        Point_gun[0].GetComponent<weapon>().Time_delay=0.7f;
                        Point_gun[1].GetComponent<weapon>().Time_delay=0.7f;
                }
                if(level_bullet==5)
                {
                        weaponship.Time_delay=speed_level[5];
                        Point_gun[0].GetComponent<weapon>().Time_delay=0.5f;
                        Point_gun[1].GetComponent<weapon>().Time_delay=0.5f;
                }
                if(level_bullet>=6)
                {
                        StartCoroutine(Warnning_max_level(0.4f,"Level Max"));
                }

             }
             else if (this.gameObject.name=="Ship_2"){
                StartCoroutine(Effect_upgrade_bullet(1,0,0,1));
                level_bullet+=1;
                if(level_bullet==1)
                {
                        weaponship.Time_delay=speed_level[1];
                }
                if(level_bullet==2)
                {
                        weaponship.Time_delay=speed_level[2];
                }
                if(level_bullet==3)
                {
                        weaponship.Time_delay=speed_level[3]; 
                        bt_fire.SetActive(true);
                }
                if(level_bullet==4)
                {
                        time_until_ship_2+=1f;
                        weaponship.Time_delay=speed_level[4];
                }
                if(level_bullet==5)
                {
                        time_until_ship_2+=1f;
                        weaponship.Time_delay=speed_level[5];
                }
                if(level_bullet>=6)
                {
                        StartCoroutine(Warnning_max_level(0.4f,"Level Max"));
                }
             }   
        }
        if(other.gameObject.tag=="item_shield")
        { 
                bt_shield.SetActive(true);
                count_shield+=1;
              
        }
    }

        public  void Button_Fire_laser()
        {
                if(check_util==false)
                {       
                        StartCoroutine(Wait_fire_laser(time_until_ship_2));
                }
        }
         public  void Button_Shield()
        {
                if(this.gameObject.name=="Ship_1")
                {
                        if(check_shield==false)
                        {

                        StartCoroutine(Wait_Shield(4f));
                        
                        }
                }
          
                if(this.gameObject.name=="Ship_2")
                {
                        if(check_shield==false)
                        {
                        StartCoroutine(Wait_Shield(4f));
                        }
                }
        }

     IEnumerator Effect_health(float color1,float color2,float color3,float color4)
    {
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
    }
        IEnumerator Effect_upgrade_bullet(float color1,float color2,float color3,float color4)
    {
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(color1,color2,color3,color4);
        yield return new WaitForSeconds(0.2f);
        Sprite_ship.color =new Color(1f,1f,1f,1f);
    }
         IEnumerator Wait_fire_laser(float time_fire)//wait bắn laser trong mấy giây khi ấn button
    {
        float temp=weaponship.Time_delay;
        weaponship.Time_delay=speed_level[0]+0.2f;
        check_util=true;
        bt_fire.GetComponent<Image>().color=new Color(1f,0f,0f,1f);
        Point_gun[0].SetActive(true);
        Point_gun[1].SetActive(true);
        yield return new WaitForSeconds(time_fire);
        weaponship.Time_delay=temp;
        bt_fire.GetComponent<Image>().color=new Color(1f,1f,1f,1f);
        check_util=false;
        Point_gun[0].SetActive(false);
        Point_gun[1].SetActive(false);
    }
    
        IEnumerator Wait_Shield(float time)
    {
        shield.SetActive(true);
         check_shield=true;   
         count_shield-=1;
         PlayerPrefs.SetInt("count_shield",count_shield); 
         bt_shield.GetComponentInChildren<Text>().text=count_shield.ToString();
         bt_shield.GetComponent<Image>().color=new Color(1f,0f,0f,1f);
         yield return new WaitForSeconds(time);
         bt_shield.GetComponent<Image>().color=new Color(1f,1f,1f,1f);
         shield.SetActive(false);
         check_shield=false;
    }
    
     IEnumerator Warnning_max_level(float Time_delay,string text_warning)
    {
        Text_max_level.SetActive(true);
        Text_max_level.GetComponent<Text>().text=text_warning;
        yield return new WaitForSeconds(Time_delay);
        Text_max_level.SetActive(false);
        Text_max_level.GetComponent<Text>().text=text_warning;
        yield return new WaitForSeconds(Time_delay);
        Text_max_level.SetActive(true);
        Text_max_level.GetComponent<Text>().text=text_warning;
        yield return new WaitForSeconds(Time_delay);
        Text_max_level.SetActive(false);
        Text_max_level.GetComponent<Text>().text=text_warning;
        yield return new WaitForSeconds(Time_delay);
        Text_max_level.SetActive(true);
        Text_max_level.GetComponent<Text>().text=text_warning;
        yield return new WaitForSeconds(Time_delay);
        Text_max_level.SetActive(false);
    }

}

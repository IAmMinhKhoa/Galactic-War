using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Manger_game : MonoBehaviour
{

    public GameObject Enemy; //thiện thạch
 public List<GameObject> Boss;
    bool check_Boss=false;
    public List<GameObject> Ship;
    Manager_Score M_Score;
    Control_spawn_enemy M_spawm_enemy;
    int choose_skin=0;
    int coin=0;
    int temp;
    bool check_1_time=false;
    public List<GameObject> Item;
    public float spawn_rate=4f;
    private float next_spawm=0f;
    public GameObject canvas_end;
    public Text text_score;
    public GameObject setting;
    public List<GameObject> Img_hero_boss;
    public GameObject text_demo;
    
    void Start()
    {
        M_Score =FindObjectOfType<Manager_Score>();
        M_spawm_enemy =FindObjectOfType<Control_spawn_enemy>();
        Load();
         temp=coin;
      //  Debug.Log(temp);
        Ship[choose_skin].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(coin);
     text_score.text="Score: "+M_Score.score.ToString();
        spawm_item();
                
        if(M_Score.score==2000 &&check_Boss==false)
        {
           
            Go_Boss(0,0);
            check_Boss=true;
        }
        else if(M_Score.score>=7000&& M_Score.score <10000)
        {
            Enemy.SetActive(true);
            M_spawm_enemy.spawn_rate=0.9f;
        }
        else if(M_Score.score==10000&&check_Boss==true)
        {
           Go_Boss(1,1);
           check_Boss=false;
        }
        else if(M_Score.score>=20000&& M_Score.score <30000)
        {
            Enemy.SetActive(true);
            M_spawm_enemy.spawn_rate=0.5f;
        }
        else if(M_Score.score==30000 &&check_Boss==false)
        {
          Go_Boss(2,2);
          check_Boss=true;
        }
        else if(M_Score.score==45000 && check_Boss==true)
        {
            text_demo.SetActive(true);
        }
        if(Ship[choose_skin].GetComponent<Control_Ship>().health_ship<=0 &&check_1_time ==false)
        {
            canvas_end.SetActive(true);
            coin=temp +M_Score.score;
            save();
        }
        
        

    }

    void Go_Boss(int hero,int Boss)
    {
            Enemy.SetActive(false);
            StartCoroutine(Show_Hero_Boss(hero,Boss));
    }
    void Load()
    {
        choose_skin =PlayerPrefs.GetInt("choose_skin");
        coin=PlayerPrefs.GetInt("coin");
    }

   void save()
   {
        PlayerPrefs.SetInt("coin",coin); 
   }
  
    void spawm_item()
    {
        if(Time.time>next_spawm)
        {
        next_spawm=Time.time+spawn_rate;
        float x_1=Random.Range(10f,30f);
        float y_1=Random.Range(-4.3f,4.3f);
        Vector2 spawm_item_1=new Vector2(x_1,y_1);
        int int_item =Random.Range(0,Item.Count);
        Instantiate(Item[int_item],spawm_item_1,Quaternion.identity,this.transform);
        }
    }
   public void return_menu()
    {
        SceneManager.LoadScene("Second_Menu");
    }
    public void pause () {
            Time.timeScale=0f;
            setting.SetActive(true);
    }
     public void resume () {
            Time.timeScale=1f;
            setting.SetActive(false);
    }  
    IEnumerator Show_Hero_Boss(int hero,int boss)//hero là số thự tự các hình hero của từng boss, boss là thứ tự boss ra
    {
        Img_hero_boss[hero].SetActive(true);
        yield return new WaitForSeconds(7f);
        Img_hero_boss[hero].SetActive(false);
        Boss[boss].SetActive(true);
    }

}

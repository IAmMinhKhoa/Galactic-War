using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class next_scence : MonoBehaviour
{
    // Start is called before the first frame update
    
   public List<GameObject> Skin; 
   
 public int choose_skin=0;
 public int coin;
 public Text txt_coin;
 public GameObject bt_buy;
 public int check_buy=0;
 public int count_shield=0;
 public GameObject txt_warning;
 public GameObject store;
 public Text txt_count_shield;
 public int Price_shield=3000;
    void Start()
    {
        Load();
        choose_skin=0;
        Save();
        Skin[0].SetActive(true);
         count_shield  =PlayerPrefs.GetInt("count_shield");
        
    }

    // Update is called once per frame
    void Update()
    {
    //  Debug.Log(coin);
        txt_coin.text="Coin : "+coin.ToString();
        txt_count_shield.text=count_shield.ToString();
    }
    public void NextOption()
    {
        Off_Ship(choose_skin);
        choose_skin+=1;
        
        if(choose_skin==Skin.Count)
        {
            choose_skin=0;
        }
        On_Ship(choose_skin);
        if(choose_skin==1&& check_buy==0)
        {
            bt_buy.SetActive(true);
        }
        else
        {
            bt_buy.SetActive(false);
        }
        Save();
    }


    void On_Ship(int choose)
    {
            Skin[choose].SetActive(true);
          //  Debug.Log("bat"+choose);
          
    }
    void Off_Ship(int choose)
    {
            Skin[choose].SetActive(false);
           // Debug.Log("tat"+choose);
    }
    public void PlayGame()
    {
            SceneManager.LoadScene("Game_Play");
    }
    public void buy_ship()
    {
        if(coin>=50000)
        {
            coin-=50000;
            check_buy=1;
            bt_buy.SetActive(false);
            PlayerPrefs.SetInt("coin",coin); 
        }
        else{
            StartCoroutine(Warnning_not_enought());
        }
    }
     IEnumerator Warnning_not_enought()
    {
        txt_warning.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        txt_warning.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        txt_warning.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        txt_warning.SetActive(false);
    }
    private void Load()
    {
        choose_skin =PlayerPrefs.GetInt("choose_skin");
        coin =PlayerPrefs.GetInt("coin");
        check_buy =PlayerPrefs.GetInt("check_buy");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("choose_skin",choose_skin);
        PlayerPrefs.SetInt("coin",coin); 
        PlayerPrefs.SetInt("check_buy",check_buy); 
        
    }
    public void return_firt_menu()
    {
         SceneManager.LoadScene("First_Menu");
    }
    public void buy_one_shield()
    {
        if(coin>=Price_shield)
        {
            coin-=Price_shield;
            count_shield++;
            PlayerPrefs.SetInt("count_shield",count_shield); 
            PlayerPrefs.SetInt("coin",coin); 
        }
        else
        {
            StartCoroutine(Warnning_not_enought());
        }
    

    }
    public void Store()
    {
        store.SetActive(true);
    }
    public void Out_Store()
    {
        store.SetActive(false);
    }
}

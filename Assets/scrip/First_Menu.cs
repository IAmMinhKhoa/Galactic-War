using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class First_Menu : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject Br;
   public GameObject Frame_plot;
   public GameObject Text_Plot;
   public GameObject Canvas_Play_Plot;//các button play plot
   float color1=1;
   float color2=1;
   float color3=1;
   public int smooth_br_change;
   bool check_plot=false;
   void Start()
   {
       
   }
   void Update()
   {
       if(check_plot)
       {
           change_color_br();
       }

   }
   void change_color_br()
   {
        Br.GetComponent<SpriteRenderer>().color=new Color(color1,color2,color3);
        color1 -=Time.smoothDeltaTime/smooth_br_change;
        color2 -=Time.smoothDeltaTime/smooth_br_change;
        color3 -=Time.smoothDeltaTime/smooth_br_change;
   }
    public void Play()
    {
         SceneManager.LoadScene("Second_Menu");
    }
    public void Plot()
    {
         Br.GetComponent<Control_spawn_enemy>().enabled=false;
        check_plot=true;
        Frame_plot.SetActive(true);
        Canvas_Play_Plot.SetActive(false);
       
       Text_Plot.GetComponent<Text_Animat>().reset();
       
    }
    public void Out_Plot()
    {
        check_plot=false;
        Frame_plot.SetActive(false);
        Canvas_Play_Plot.SetActive(true);
        
        Br.GetComponent<Control_spawn_enemy>().enabled=true;
        Br.GetComponent<SpriteRenderer>().color=new Color(1,1,1);
        color1=color2=color3=1;
    }
}

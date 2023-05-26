using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_Animat : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> txt;
   public int y=0; 
    
    public Text Show_txt;
    
   public List<int> char_index;
   public int x=0;
    float timer;
    public float time_per_char;
    void Start()
    {
        txt[0]="Câu chuyện được lấy cảm hứng từ các vị thần Bắc Âu và chuyển thể thành cuộc chiến giữa các phi thuyền không gian";
        txt[1]="Chuyện kể rằng 3 chị em nhà Odin đã lên kế hoạch đảo chính và soán ngôi vương của cha họ là Odin, để có thể cai trị vùng đất của các vị thần ASGARD";
        txt[2]="3 kẻ đã lập nên kế hoạch đó là";
        txt[3]="Chị cả Hela, Thor và em út Loki";
        txt[4]="Sau khi sát hại thành công cha của họ là Odin, kế hoạch của họ chỉ còn vài bước là có thể cai trị xứ ASGARD";
        txt[5]="Nhưng những vị thần khác đã đứng ra đấu tranh chống lại 3 người họ, nhằm ngăn cản sự cai trị độc tài của chúng";
    
    
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.smoothDeltaTime;
        if(timer<=0)
        {
            timer+=time_per_char;  
            if(char_index[x]<=txt[y].Length )
            {
                char_index[x]++;
                read_text(char_index[x],txt[y]);
            }
            else{
                x++;
                y++;
            }
        }
    }
    public void read_text(int char_index,string txt)
    {
        Show_txt.text=txt.Substring(0,char_index);
    }
    public void reset () {
        x=0;
        y=0;
        for(int i=0;i<=char_index.Count;i++)
            char_index[i]=0;
    }
}

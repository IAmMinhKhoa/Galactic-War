using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_spawn_enemy : MonoBehaviour
{
    
    float rand_position;
    Vector2 spawn_position;
    public float spawn_rate=4f;
    private float next_spawm=0f;
    public List<GameObject> enemy_list;
    private GameObject random_enemy;
   
    // Update is called once per frame
    void Update()
    {     
        SpawmEnemy();
    }


    private GameObject RandomEnemy()
    {
        int random_temp=Random.Range(0,enemy_list.Count);   
        random_enemy=enemy_list[random_temp];
        return random_enemy;
    }
    private void SpawmEnemy()
    {
        if(Time.time>next_spawm)
        {
            next_spawm=Time.time +spawn_rate;
            rand_position=Random.Range(-3f,3f);
            float x=Random.Range(9.5f,15f);
            spawn_position =new Vector2(x,rand_position);
            Instantiate(RandomEnemy(),spawn_position,Quaternion.identity,this.transform);
        }
    }


}

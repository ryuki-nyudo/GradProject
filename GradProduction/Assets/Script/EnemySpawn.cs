using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private bool spawn;
    GameObject Enemy;    //Enemyオブジェクト情報
    private int EnemyMaxNum;    //出現Enemy
    private int EnemyNum;
    private int SpawnNum;
    private int MaxSpawn = 10;
    Vector3 EInitPosition; //Enemy初期座標

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = (GameObject)Resources.Load ("EnemyTestCube");
        EnemyNum = 0;
        EnemyMaxNum = 1;  

        EInitPosition = GameObject.Find("EnemySpawn").transform.position;

        //時間処理
        time = 0.0f;

        spawn = true;
        SpawnNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー開始
        time += Time.deltaTime;

        if(spawn == true){
            //3体出すを2秒経ったら実行
            for(; EnemyNum < EnemyMaxNum && time >= 2.0f; ){
                Instantiate (Enemy, EInitPosition, Quaternion.identity);
                EnemyNum++;
                if(EnemyNum == EnemyMaxNum){
                    spawn = false;
                    SpawnNum++;
                }
                //タイマーリセット
                time = 0.0f;
            }
        }
        else if(SpawnNum < MaxSpawn) {
            if(time >= 9.0f){
                spawn = true;
                time = 0.0f;
                EnemyNum = 0;
            }
        }
    }
}

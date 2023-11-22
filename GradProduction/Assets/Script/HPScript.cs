using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
     // 敵のヒットポイントを設定
    public int HP;
    private int wkHP;

    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        //tagによってHPを変える
        if (gameObject.CompareTag("Player")){
            HP = 100;
        }
        else if(gameObject.CompareTag("Enemy")){
            HP = 100;
        }

        hpSlider.value = (float)HP;
        wkHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        // スライダーの向きをカメラ方向に固定
        hpSlider.transform.rotation = Camera.main.transform.rotation;
        
        //HP処理
        hpSlider.value = (float)HP / (float)wkHP;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

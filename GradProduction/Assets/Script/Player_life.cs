using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_life : MonoBehaviour
{
    public Text HPText;
    private int count = 10; // ライフの数

   private void Start()
   {
       
        HPText.text = count.ToString(); //10が入ってる。
       
    }
    void OnCollisionEnter(Collision other)
    {
        // ボールにぶつかったとき
        if (other.gameObject.tag == "Enemy")
        {
          --count;//ライフを1減らす
            Debug.Log(count);
            HPText.text = count.ToString();
           
        }
        else
        {

        }
    }
}
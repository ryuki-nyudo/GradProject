using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_life : MonoBehaviour
{
    public Text HPText;
    private int count = 10; // ���C�t�̐�

   private void Start()
   {
       
        HPText.text = count.ToString(); //10�������Ă�B
       
    }
    void OnCollisionEnter(Collision other)
    {
        // �{�[���ɂԂ������Ƃ�
        if (other.gameObject.tag == "Enemy")
        {
          --count;//���C�t��1���炷
            Debug.Log(count);
            HPText.text = count.ToString();
           
        }
        else
        {

        }
    }
}
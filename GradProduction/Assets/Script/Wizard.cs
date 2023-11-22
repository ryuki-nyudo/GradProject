using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    /*�z��̏����i���jLIST(��)*/
    private List<GameObject> enemyList = new List<GameObject>();
    private int ObjectCount;
    /**/
    private SphereCollider sphereCollider;
    private float timeElapsed;
    private int levelNumber;

    private double AS;  /*�A�^�b�N�X�s�[�h*/
    private int ATK;    /*�A�^�b�N�_���[�W*/
    private float Area;   /*�U���͈�*/
    private float Target;

    HPScript hpScript;  //HPScript

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        timeElapsed = 0;
        levelNumber = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //sphereCollider.radius = Area;
        Level();

        if (enemyList.Count > 0)
        {
            GameObject element = enemyList[0];
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= AS)
            {

                /*���̒��ɓG���w�肵�čU�����鏈��������*/
                GameObject firstEnemy = enemyList[0];   //�z��ŏ��̓G

                hpScript = firstEnemy.GetComponent<HPScript>();

                hpScript.HP -= ATK;

                Debug.Log("�U��");
                timeElapsed = 0;

                if (hpScript.HP <= 0)
                {
                    enemyList.RemoveAt(0);
                }
            }
        }


        ///*�e�X�g�G���A*/
        //if (Input.GetMouseButtonDown(0))
        //{
        //    hpScript.HP -= 1;
        //    Debug.Log("���N���b�N");
        //}



        /*�e�X�g�G���A*/
    }
    void OnTriggerEnter(Collider other)  /*�����G���͈͓��ɓ�������*/
    {

        if (other.gameObject.tag == "Enemy")    /*�^�O��Enemy��������*/
        {
            enemyList.Add(other.gameObject);
        }
    }



    void OnTriggerExit(Collider other)
    {
        enemyList.RemoveAt(0);
    }

    void Level()
    {
        switch (levelNumber)
        {
            case 1:
                ATK = 15;
                AS = 0.7;
                Area = 4f;
                Target = 3;
                break;
            case 2:
                ATK = 15;
                AS = 0.7;
                Area = 4f;
                Target = 4;
                break;
            case 3:
                ATK = 20;
                AS = 0.7;
                Area = 5f;
                Target = 5;
                break;
        }
    }
}

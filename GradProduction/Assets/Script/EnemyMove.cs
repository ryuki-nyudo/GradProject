
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    //移動ターゲット
	[SerializeField]
	private Transform m_Target;
    [SerializeField]
	private Transform m_Goal;

    //NavMeshのエリア獲得
	private NavMeshAgent m_Agent;

    //ターゲットからゴールに移動変更
    private bool change = false;

    //防衛キャラ接敵
    public bool BlockObj;
    public bool BlockPlayer;
    HPScript hpScript;  //壁兵士HPScript

    //敵攻撃
    private double AS = 0.5f;  //攻撃速度
    private int ATK = 1;      //攻撃力
    private float ATKtime;
    
	void Start()
	{
		m_Agent = GetComponent<NavMeshAgent>();
        change = false;
        BlockObj = false;
        BlockPlayer = false;

        ATKtime = 0.0f;
	}

	void Update()
	{
        if(BlockObj == false){
            if(change == false){    //ターゲットに通過するまでゴールにいかないようにする
                m_Agent.SetDestination(m_Target.position);
            }
            else {
                m_Agent.SetDestination(m_Goal.position);
            }
        }
        else if(BlockPlayer == true){
            m_Agent.isStopped = true;
            ATKtime += Time.deltaTime;
            if(ATKtime >= AS){
                hpScript.HP -= ATK;
                ATKtime = 0.0f;
            }

            if(hpScript.HP <= 0){
                m_Agent.isStopped = false;
                BlockPlayer = false;
                BlockObj = false;
            }
        }
	}

    void OnTriggerEnter(Collider other){
        //ターゲットに触れたらゴールに移動する
        if(other.gameObject.tag == "Target"){   
            change = true;
            //Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Block"){
            BlockObj = true;
        }
        else if(other.gameObject.tag == "Player"){
            BlockObj = true;
            BlockPlayer = true;
            hpScript = other.gameObject.GetComponent<HPScript>();
        }
    }
}
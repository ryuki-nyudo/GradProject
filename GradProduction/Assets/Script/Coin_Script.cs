using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject objectPrefab; // �ݒu����I�u�W�F�N�g�̃v���n�u
                                    // Update is called once per frame
    private void Update()
    {
        // �}�E�X�̍��N���b�N�������ꂽ��
        if (Input.GetMouseButtonDown(0))
        {
            // �}�E�X�̃X�N���[�����W��Ray�ɕϊ�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray���I�u�W�F�N�g�ɓ����������`�F�b�N
            if (Physics.Raycast(ray, out hit))
            {
                // Ray�����������ʒu�ɃI�u�W�F�N�g�𐶐�
                Instantiate(objectPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}



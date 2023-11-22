using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    public GameObject towerPrefab; // TowerTest�̃v���n�u
    private bool towerSpawned = false;

    void Start()
    {
        // �{�^���ɃN���b�N���̏�����ǉ�
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��ɌĂяo�����֐�
    private void OnButtonClick()
    {
        // �܂��^���[���X�|�[������Ă��Ȃ��ꍇ
        if (!towerSpawned)
        {
            SpawnTowerAtPosition(new Vector3(-8.25f, 4f, 61.3f));
            towerSpawned = true; // �X�|�[���ς݃t���O��ݒ�
        }
    }

    // �w�肳�ꂽ���W�Ƀ^���[���X�|�[������֐�
    private void SpawnTowerAtPosition(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}

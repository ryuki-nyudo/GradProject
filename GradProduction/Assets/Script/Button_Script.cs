using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    public GameObject towerPrefab; // TowerTestのプレハブ
    private bool towerSpawned = false;

    void Start()
    {
        // ボタンにクリック時の処理を追加
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }

    // ボタンがクリックされたときに呼び出される関数
    private void OnButtonClick()
    {
        // まだタワーがスポーンされていない場合
        if (!towerSpawned)
        {
            SpawnTowerAtPosition(new Vector3(-8.25f, 4f, 61.3f));
            towerSpawned = true; // スポーン済みフラグを設定
        }
    }

    // 指定された座標にタワーをスポーンする関数
    private void SpawnTowerAtPosition(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);
    }
}

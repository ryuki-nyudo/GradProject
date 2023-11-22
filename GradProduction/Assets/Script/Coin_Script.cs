using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject objectPrefab; // 設置するオブジェクトのプレハブ
                                    // Update is called once per frame
    private void Update()
    {
        // マウスの左クリックが押されたら
        if (Input.GetMouseButtonDown(0))
        {
            // マウスのスクリーン座標をRayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Rayがオブジェクトに当たったかチェック
            if (Physics.Raycast(ray, out hit))
            {
                // Rayが当たった位置にオブジェクトを生成
                Instantiate(objectPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}




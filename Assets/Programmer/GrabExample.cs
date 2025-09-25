using UnityEngine;

public class GrabExample : MonoBehaviour
{
    public Transform player;     // プレイヤー
    public Transform target;     // 掴みたいオブジェクト
    private bool isGrabbed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!isGrabbed)
            {
                // 子オブジェクトにする
                target.SetParent(player);
                // プレイヤーの前に移動（必要に応じて調整）
                target.localPosition = new Vector3(0f, 1f, 1f);
                isGrabbed = true;
            }
            else
            {
                // 親子関係を解除
                target.SetParent(null);
                isGrabbed = false;
            }
        }
    }
}

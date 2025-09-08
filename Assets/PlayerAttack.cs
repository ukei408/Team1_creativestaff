using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Update()
    {
        // 攻撃
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 攻撃処理（例：アニメーション再生、敵へのダメージなど）
        Debug.Log("攻撃した！");
        // ここに攻撃アニメーションやヒット判定などを追加できます
    }
}

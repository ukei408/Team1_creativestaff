using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("攻撃設定")]
    public float attackRange = 1.5f;   // 攻撃範囲
    public int attackDamage = 1;       // ダメージ量
    public LayerMask enemyLayer;       // 敵のレイヤーを設定

    void Update()
    {
        // Fキーで攻撃
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        // 一定範囲内の敵を取得（Sphere判定）
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Enemyスクリプトを持っていたらダメージを与える
            Enemy e = enemy.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(attackDamage);
            }
        }
    }

    // 攻撃範囲をSceneビューで可視化
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

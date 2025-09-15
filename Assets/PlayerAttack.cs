using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackPower = 1;         // ダメージ量
    public float attackRange = 1.0f;    // 攻撃の届く距離
    public LayerMask enemyLayer;        // 敵レイヤーを指定

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("攻撃した！");

        // プレイヤーの位置から前方に円を出して、当たった敵を検出
        Vector2 attackPos = transform.position;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyController ec = enemy.GetComponent<EnemyController>();
            if (ec != null)
            {
                ec.TakeDamage(attackPower);
            }
        }
    }

    // Sceneビューで攻撃範囲を見えるようにする
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

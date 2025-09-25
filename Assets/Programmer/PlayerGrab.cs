using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [Header("掴み設定")]
    public float grabRange = 2f;       // 掴める距離
    public Transform grabPoint;        // 掴んだ敵を置く位置
    public LayerMask enemyLayer;
    public float throwForce = 10f;     // 投げる力

    private Enemy grabbedEnemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (grabbedEnemy == null)
            {
                TryGrab();
            }
            else
            {
                Throw();
            }
        }
    }

    void TryGrab()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, grabRange, enemyLayer);

        if (enemies.Length > 0)
        {
            Enemy enemy = enemies[0].GetComponent<Enemy>();
            if (enemy != null)
            {
                grabbedEnemy = enemy;
                grabbedEnemy.Grab(grabPoint);
            }
        }
    }

    void Throw()
    {
        if (grabbedEnemy != null)
        {
            // プレイヤーがどっち向いてるかで投げる方向を変える
            float dir = transform.localScale.x > 0 ? 1f : -1f;
            Vector3 throwDir = new Vector3(dir, 0f, 0f); // X軸方向のみ

            grabbedEnemy.Throw(throwDir, throwForce);
            grabbedEnemy = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}

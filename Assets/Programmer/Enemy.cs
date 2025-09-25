using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    [HideInInspector] public bool isGrabbed = false;
    private Rigidbody rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        if (isGrabbed) return; // 掴まれてる間はダメージ無効

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 掴むとき
    public void Grab(Transform grabPoint)
    {
        isGrabbed = true;
        rb.isKinematic = true;
        rb.detectCollisions = false;

        transform.parent = grabPoint;
        transform.position = grabPoint.position; // ← ここをローカル座標じゃなくワールド座標に
    }
    public void Throw(Vector3 direction, float force)
    {
        isGrabbed = false;
        transform.parent = null;
        rb.isKinematic = false;
        rb.detectCollisions = true; // 衝突判定ON
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
        }

        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    }
}

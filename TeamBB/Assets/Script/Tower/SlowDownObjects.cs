using UnityEngine;

public class SlowDownObjects : MonoBehaviour
{
    public string targetTag = "SpawneObject";
    public float slowDownFactor = 0.5f; // 이 값을 조절하여 속도를 조절할 수 있습니다.

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 태그를 가지고 있는지 확인합니다.
        CheckAndSlowDown(other);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 태그를 가지고 있는지 확인합니다.
        CheckAndSlowDown(collision.collider);
    }

    // 태그를 가지고 있다면 속도를 느리게 하는 메서드
    void CheckAndSlowDown(Collider collider)
    {
        // 충돌한 오브젝트가 지정한 태그를 가지고 있는지 확인합니다.
        if (collider.CompareTag(targetTag))
        {
            // 충돌한 오브젝트의 Rigidbody 컴포넌트를 가져옵니다.
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            // Rigidbody가 존재하고 속도를 느리게 합니다.
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}

using UnityEngine;

public class SlowDownObjects : MonoBehaviour
{
    public string targetTag = "SpawneObject";
    public float slowDownFactor = 0.5f; // 이 값을 조절하여 속도를 조절할 수 있습니다.

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 지정한 태그를 가지고 있는지 확인합니다.
        if (other.CompareTag(targetTag))
        {
            // 충돌한 오브젝트의 Rigidbody 컴포넌트를 가져옵니다.
            Rigidbody rb = other.GetComponent<Rigidbody>();

            // Rigidbody가 존재하고 속도를 느리게 합니다.
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}

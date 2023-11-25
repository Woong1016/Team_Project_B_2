using UnityEngine;

public class SlowDownObjects : MonoBehaviour
{
    public string targetTag = "SpawneObject";
    public float slowDownFactor = 0.5f; // �� ���� �����Ͽ� �ӵ��� ������ �� �ֽ��ϴ�.

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� ������ �±׸� ������ �ִ��� Ȯ���մϴ�.
        if (other.CompareTag(targetTag))
        {
            // �浹�� ������Ʈ�� Rigidbody ������Ʈ�� �����ɴϴ�.
            Rigidbody rb = other.GetComponent<Rigidbody>();

            // Rigidbody�� �����ϰ� �ӵ��� ������ �մϴ�.
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}

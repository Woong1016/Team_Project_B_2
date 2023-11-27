using UnityEngine;

public class SlowDownObjects : MonoBehaviour
{
    public string targetTag = "SpawneObject";
    public float slowDownFactor = 0.5f; // �� ���� �����Ͽ� �ӵ��� ������ �� �ֽ��ϴ�.

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±׸� ������ �ִ��� Ȯ���մϴ�.
        CheckAndSlowDown(other);
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±׸� ������ �ִ��� Ȯ���մϴ�.
        CheckAndSlowDown(collision.collider);
    }

    // �±׸� ������ �ִٸ� �ӵ��� ������ �ϴ� �޼���
    void CheckAndSlowDown(Collider collider)
    {
        // �浹�� ������Ʈ�� ������ �±׸� ������ �ִ��� Ȯ���մϴ�.
        if (collider.CompareTag(targetTag))
        {
            // �浹�� ������Ʈ�� Rigidbody ������Ʈ�� �����ɴϴ�.
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            // Rigidbody�� �����ϰ� �ӵ��� ������ �մϴ�.
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}

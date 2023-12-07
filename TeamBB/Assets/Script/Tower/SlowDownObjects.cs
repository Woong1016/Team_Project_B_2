using UnityEngine;

public class SlowDownObjects : MonoBehaviour
{
    public string targetTag = "SpawneObject";
    public float slowDownFactor = 0.5f; // �� ���� �����Ͽ� �ӵ��� ������ �� �ֽ��ϴ�.

    void OnTriggerEnter(Collider other)
    {
        // Do nothing for OnTriggerEnter
    }

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� ������ �±׸� ������ �ִ��� Ȯ���մϴ�.
        if (collision.collider.CompareTag(targetTag))
        {
            // �浹�� ������Ʈ�� Rigidbody ������Ʈ�� �����ɴϴ�.
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            // Rigidbody�� �����ϰ� �ӵ��� ������ �մϴ�.
            if (rb != null)
            {
                rb.velocity *= slowDownFactor;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TowerMerge : MonoBehaviour
{
    public GameObject followingObjectPrefab;
    private GameObject followingObject;
    private bool isEvolving = false;

    void Start()
    {
        followingObject = Instantiate(followingObjectPrefab);
        followingObject.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ�� OnClickEvolveButton �޼ҵ� ����
        Button evolveButton = GameObject.Find("�Ҵ�").GetComponent<Button>();
        evolveButton.onClick.AddListener(OnClickEvolveButton);
    }

    void Update()
    {
        // ���콺 �Է� ������ �����մϴ�.
        if (Input.GetMouseButtonDown(0) && !isEvolving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("�Ҵ�"))
                {
                    followingObject.SetActive(true);
                    followingObject.transform.position = hit.point;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && followingObject.activeSelf)
        {
            followingObject.SetActive(false);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Tower"))
                {
                    EvolveTower();
                }
            }
        }
    }
    [SerializeField]
    private void OnClickEvolveButton()
    {
        // ��ư�� Ŭ���Ǿ��� ���� ����
        // ���⼭�� Ÿ�� ��ȭ ������ ȣ���մϴ�.
        EvolveTower();
    }

    void EvolveTower()
    {
        GameObject newTower = Instantiate(followingObjectPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

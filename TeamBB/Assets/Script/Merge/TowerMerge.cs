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

        // 버튼 클릭 이벤트에 OnClickEvolveButton 메소드 연결
        Button evolveButton = GameObject.Find("불닭").GetComponent<Button>();
        evolveButton.onClick.AddListener(OnClickEvolveButton);
    }

    void Update()
    {
        // 마우스 입력 로직은 유지합니다.
        if (Input.GetMouseButtonDown(0) && !isEvolving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("불닭"))
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
        // 버튼이 클릭되었을 때의 동작
        // 여기서는 타워 진화 로직을 호출합니다.
        EvolveTower();
    }

    void EvolveTower()
    {
        GameObject newTower = Instantiate(followingObjectPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

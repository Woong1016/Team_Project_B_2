using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
  
    public List<Vector3> path1; // 동선 1
    
    public List<Vector3> path2; // 동선 2
    
    public List<Vector3> path3; // 동선 3

    // 다른 동선을 필요에 따라 추가할 수 있습니다.

    public List<Vector3> GetPath(int pathNumber)
    {
        switch (pathNumber)
        {
            case 1:
                return path1;
            case 2:
                return path2;
            case 3:
                return path3;
            default:
                Debug.LogWarning("Invalid path number!");
                return null;
        }
    }







    void Start()
    {
        // 동선 초기화
        path1 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint2").transform.position,
        GameObject.Find("WayPoint3").transform.position,
       
        };

        path2 = new List<Vector3>
        {
            new Vector3(3, 0, 3),
            new Vector3(4, 0, 3),
            new Vector3(4, 0, 4),
            new Vector3(3, 0, 4),
        };

        path3 = new List<Vector3>
        {
            new Vector3(5, 0, 5),
            new Vector3(6, 0, 5),
            new Vector3(6, 0, 6),
            new Vector3(5, 0, 6),
        };
        path3 = new List<Vector3>
        {
            new Vector3(5, 0, 5),
            new Vector3(6, 0, 5),
            new Vector3(6, 0, 6),
            new Vector3(5, 0, 6),
        };
        path3 = new List<Vector3>
        {
            new Vector3(5, 0, 5),
            new Vector3(6, 0, 5),
            new Vector3(6, 0, 6),
            new Vector3(5, 0, 6),
        };
        path3 = new List<Vector3>
        {
            new Vector3(5, 0, 5),
            new Vector3(6, 0, 5),
            new Vector3(6, 0, 6),
            new Vector3(5, 0, 6),
        };
        path3 = new List<Vector3>
        {
            new Vector3(5, 0, 5),
            new Vector3(6, 0, 5),
            new Vector3(6, 0, 6),
            new Vector3(5, 0, 6),

        };


        // 다른 초기화 코드 추가
    }



}


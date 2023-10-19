using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{

    public List<List<Vector3>> paths = new List<List<Vector3>>();


    public List<Vector3> GetRandomPath()
    {
        if (paths.Count == 0)
        {
            Debug.LogWarning("No paths available.");
            return null;
        }

        int randomIndex = Random.Range(0, paths.Count);
        return paths[randomIndex];
    }



    public List<Vector3> path1; // 동선 1
    public List<Vector3> path2; // 동선 2
    public List<Vector3> path3; // 동선 3
    public List<Vector3> path4; // 동선 4
    public List<Vector3> path5; // 동선 5
    public List<Vector3> path6; // 동선 6
    public List<Vector3> path7; // 동선 7
    public List<Vector3> path8; // 동선 8
    public List<Vector3> path9; // 동선 9
    public List<Vector3> path10; // 동선 10
    public List<Vector3> path11; // 동선 11
    public List<Vector3> path12; // 동선 12
    public List<Vector3> path13; // 동선 13
    public List<Vector3> path14; // 동선 14


    

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
            case 4:
                return path4;
            case 5:
                return path5;
            case 6:
                return path6;
            case 7:
                return path7;
            case 8:
                return path8;
            case 9:
                return path9;
            case 10:
                return path10;
            case 11:
                return path11;
            case 12:
                return path12;
            case 13:
                return path13;
            case 14:
                return path14;
            default:
                Debug.LogWarning("Invalid path number!");
                return null;
        }
    }







    void Awake()
    {
        // 동선 초기화
        path1 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint4").transform.position,
        GameObject.Find("WayPoint16").transform.position,
       
        };

        path2 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint3").transform.position,
        GameObject.Find("WayPoint7").transform.position,
         GameObject.Find("WayPoint8").transform.position,
         GameObject.Find("WayPoint16").transform.position,

        };

        path3 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint3").transform.position,
        GameObject.Find("WayPoint11").transform.position,
        GameObject.Find("WayPoint12").transform.position,
        GameObject.Find("WayPoint16").transform.position,



        };
        path4 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint3").transform.position,
        GameObject.Find("WayPoint15").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path5 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint2").transform.position,
        GameObject.Find("WayPoint6").transform.position,
        GameObject.Find("WayPoint8").transform.position,
        GameObject.Find("WayPoint16").transform.position,



        };
        path6 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint2").transform.position,
        GameObject.Find("WayPoint10").transform.position,
        GameObject.Find("WayPoint12").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path7 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
       GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint2").transform.position,
        GameObject.Find("WayPoint14").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path8 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint5").transform.position,
        GameObject.Find("WayPoint8").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path9 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint5").transform.position,
        GameObject.Find("WayPoint7").transform.position,
        GameObject.Find("WayPoint11").transform.position,
        GameObject.Find("WayPoint12").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path10 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint5").transform.position,
         GameObject.Find("WayPoint7").transform.position,
        GameObject.Find("WayPoint15").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path11 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint5").transform.position,
        GameObject.Find("WayPoint6").transform.position,
        GameObject.Find("WayPoint14").transform.position,
        GameObject.Find("WayPoint16").transform.position,
        };


        path12 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint9").transform.position,
        GameObject.Find("WayPoint10").transform.position,
        GameObject.Find("WayPoint14").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        path13 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint9").transform.position,
        GameObject.Find("WayPoint12").transform.position,
        GameObject.Find("WayPoint16").transform.position,
       

        };
        path14 = new List<Vector3>
        {
            // Waypoint 오브젝트의 위치를 사용하여 초기화
            // Waypoint 오브젝트의 위치를 사용하여 초기화
        GameObject.Find("WayPoint1").transform.position,
        GameObject.Find("WayPoint13").transform.position,
        GameObject.Find("WayPoint16").transform.position,

        };
        // 경로들을 paths 리스트에 추가
        paths.Add(path1);
        paths.Add(path2);
        paths.Add(path3);
        paths.Add(path4);
        paths.Add(path5);
        paths.Add(path6);
        paths.Add(path7);
        paths.Add(path8);
        paths.Add(path9);
        paths.Add(path10);
        paths.Add(path11);
        paths.Add(path12);
        paths.Add(path13);
        paths.Add(path14);

    }




        // 다른 초기화 코드 추가


    }






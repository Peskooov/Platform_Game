using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs; // ������ �������� ����
    public GameObject start; // ��������� �����
    public Transform finish; // �������� �����
    public int pathWidth; // ������ ����
    public int pathLength; // ����� ����
    public int maxTurns; // ������������ ���������� ��������� �� ����
    private List<GameObject> pathList = new List<GameObject>(); // ������ ���� �������� ����

    public int pathCount;
    public int offset;
    void Start()
    {
        //pathList.Add(start);
        //GeneratePaths();
        GeneratePathsNew();
    }

    private void GeneratePathsNew()
    {
        for (int j = 0; j < pathCount; j++)
        {
            GameObject pathStart = Instantiate(pathPrefabs[0], start.transform.position + new Vector3(j * (pathWidth + offset), 0, 0), Quaternion.identity);
            pathList.Add(pathStart);

            for (int i = 0; i < pathLength - 1; i++)
            { 
                GameObject path = Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Length)]);
                path.transform.position = pathList[pathList.Count - 1].transform.position + new Vector3(pathList[j].transform.position.x, 0, pathWidth + offset);
           
                pathList.Add(path);
            }
        }
    }

    /* void GeneratePaths()
     {
         // ���������� ��������� �����
         for (int i = 0; i < 3; i++)
         {
             // ������� ����� ����
             GameObject newPath = new GameObject("Path");
             newPath.transform.SetParent(transform);
             newPath.transform.position = start.position;
             Vector3 pathDirection = (finish.position - start.position).normalized;
            // int totalPathLength = pathLength + Random.Range(-5, 5);
             // ������� �� ����� ����
             for (int j = 0; j < pathLength; j++)
             {
                 // �������� ��������� ������ � ��������� ��� � ����

                 var pathPrefab = Instantiate(pathPrefabs[prefabIndex], newPath.transform);
                 pathPrefab.transform.localPosition = Vector3.forward * j * pathWidth;
                 // ������������ ���� � ��������� �������
                 if (Random.Range(0, 10) < 8 && j > maxTurns)
                 {
                     Vector3 oldDirection = pathDirection;
                     pathDirection = Quaternion.Euler(0, 90, 0) * pathDirection;
                     if (Physics.Raycast(newPath.transform.position, pathDirection, out RaycastHit hitInfo, pathWidth * 2))
                     {
                         pathDirection = oldDirection;
                         j--;
                         continue;
                     }
                 }
             }
             // ��������� ���� � ����� ������
             pathList.Add(newPath);
         }
     }*/
}
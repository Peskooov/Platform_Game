using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs; // ������ �������� ����
    public Transform start; // ��������� �����
    public Transform finish; // �������� �����
    public int pathWidth; // ������ ����
    public int pathLength; // ����� ����
    public int maxTurns; // ������������ ���������� ��������� �� ����
    private List<GameObject> pathList = new List<GameObject>(); // ������ ���� �������� ����

    void Start()
    {
        GeneratePaths();
    }

    void GeneratePaths()
    {
        // ���������� ��������� �����
        for (int i = 0; i < 3; i++)
        {
            // ������� ����� ����
            GameObject newPath = new GameObject("Path");
            newPath.transform.SetParent(transform);
            newPath.transform.position = start.position;
            Vector3 pathDirection = (finish.position - start.position).normalized;
            int totalPathLength = pathLength + Random.Range(-5, 5);
            // ������� �� ����� ����
            for (int j = 0; j < totalPathLength; j++)
            {
                // �������� ��������� ������ � ��������� ��� � ����
                int prefabIndex = Random.Range(0, pathPrefabs.Length);
                GameObject pathPrefab = Instantiate(pathPrefabs[prefabIndex], newPath.transform);
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
    }
}
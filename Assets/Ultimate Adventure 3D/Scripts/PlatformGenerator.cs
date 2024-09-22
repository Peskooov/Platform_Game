using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs; // массив префабов пути
    public GameObject start; // начальная точка
    public Transform finish; // конечная точка
    public int pathWidth; // ширина пути
    public int pathLength; // длина пути
    public int maxTurns; // максимальное количество поворотов на пути
    private List<GameObject> pathList = new List<GameObject>(); // список всех префабов пути

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
         // генерируем несколько путей
         for (int i = 0; i < 3; i++)
         {
             // создаем новый путь
             GameObject newPath = new GameObject("Path");
             newPath.transform.SetParent(transform);
             newPath.transform.position = start.position;
             Vector3 pathDirection = (finish.position - start.position).normalized;
            // int totalPathLength = pathLength + Random.Range(-5, 5);
             // следуем по этому пути
             for (int j = 0; j < pathLength; j++)
             {
                 // выбираем случайный префаб и добавляем его в путь

                 var pathPrefab = Instantiate(pathPrefabs[prefabIndex], newPath.transform);
                 pathPrefab.transform.localPosition = Vector3.forward * j * pathWidth;
                 // поворачиваем путь в случайную сторону
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
             // добавляем путь в общий список
             pathList.Add(newPath);
         }
     }*/
}
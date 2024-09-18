using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs; // массив префабов пути
    public Transform start; // начальная точка
    public Transform finish; // конечная точка
    public int pathWidth; // ширина пути
    public int pathLength; // длина пути
    public int maxTurns; // максимальное количество поворотов на пути
    private List<GameObject> pathList = new List<GameObject>(); // список всех префабов пути

    void Start()
    {
        GeneratePaths();
    }

    void GeneratePaths()
    {
        // генерируем несколько путей
        for (int i = 0; i < 3; i++)
        {
            // создаем новый путь
            GameObject newPath = new GameObject("Path");
            newPath.transform.SetParent(transform);
            newPath.transform.position = start.position;
            Vector3 pathDirection = (finish.position - start.position).normalized;
            int totalPathLength = pathLength + Random.Range(-5, 5);
            // следуем по этому пути
            for (int j = 0; j < totalPathLength; j++)
            {
                // выбираем случайный префаб и добавляем его в путь
                int prefabIndex = Random.Range(0, pathPrefabs.Length);
                GameObject pathPrefab = Instantiate(pathPrefabs[prefabIndex], newPath.transform);
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
    }
}
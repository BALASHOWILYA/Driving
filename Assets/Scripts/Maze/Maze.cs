using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation       
{


   

    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
}

public class Maze : MonoBehaviour
{

    //Сериализованная переменная для связи с объектом-шаблоном 
    [SerializeField] private GameObject enemyPrefab;
    //Закрытая переменная для слежения за экземпляром врага в сцене
    private GameObject _enemy;

    public List<MapLocation> directions = new List<MapLocation>() {
                                            new MapLocation(1,0),
                                            new MapLocation(0,1),
                                            new MapLocation(-1,0),
                                            new MapLocation(0,-1) };

    public int width = 30; //x length
    public int depth = 30; //z length
    public byte[,] map;
    public int scale = 6;
    //public GameObject prefab; 
    

    // Start is called before the first frame update
    void Start()
    {
        
        InitialiseMap();
        Generate();
        DrawMap();
    }

    void InitialiseMap()
    {
        map = new byte[width,depth];
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                    map[x, z] = 1;     //1 = wall  0 = corridor
            }
    }

    public virtual void Generate()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
               if(Random.Range(0,100) < 50)
                 map[x, z] = 0;     //1 = wall  0 = corridor
            }
    }

    void DrawMap()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    //PrimitiveType.Cube
                    // Instantiate(prefab, pos, Quaternion.identity);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //wall.AddComponent<MeshRenderer>();
                    wall.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    wall.tag = "Obstacle";
                }
            }

        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 0)
                {

                    Vector3 pos = new Vector3(x * scale, 1, z * scale);
                    if (pos == new Vector3(50, 1, 50)) { continue;}
                    CreateEnemies(pos);

                    
                }
            }
    }

    public void CreateEnemies(Vector3 pos)
    {
        int ManyEnemy = 3;
        for (int i = 0; i < ManyEnemy; i++)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = pos;
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            _enemy.tag = "Enemy";
        }
    }

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1)
        {
            Debug.Log("I see you");
            return 5;
        }
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;
        return count;
    }

    public int CountDiagonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z - 1] == 0) count++;
        if (map[x + 1, z + 1] == 0) count++;
        if (map[x - 1, z + 1] == 0) count++;
        if (map[x + 1, z - 1] == 0) count++;
        return count;
    }

    public int CountAllNeighbours(int x, int z)
    {
        return CountSquareNeighbours(x,z) + CountDiagonalNeighbours(x,z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class MapHandler : MonoBehaviour
{
    [SerializeField] GridCube startCube, endCube;
    Dictionary<Vector2Int, GridCube> map = new Dictionary<Vector2Int, GridCube>();
    Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
    List<GridCube> path;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    // Start is called before the first frame update
    void Start()
    {
        loadMap();
        ColorStartAndEnd();
        AStar();
        printPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColorStartAndEnd()
    {
        // todo consdier moving out
        startCube.SetTopColor(Color.black);
        endCube.SetTopColor(Color.white);
    }

    public void AStar()
    {
        MinHeap openSet = new MinHeap(map.Count);
        openSet.Add(convertVec2Int(startCube.getGridPos()));
        Dictionary<Vector2Int, int> gScore = new Dictionary<Vector2Int, int>();
        gScore.Add(startCube.getGridPos(), 0);
        Dictionary<Vector2Int, int> fScore = new Dictionary<Vector2Int, int>();
        fScore.Add(startCube.getGridPos(), heuristic(startCube.getGridPos()));
        while(!openSet.IsEmpty())
        {
            //check if we have arrived at the end
            Vector2Int current = convertInt2Vec(openSet.Pop());
            if (current == endCube.getGridPos())
            {
                path = ReconstructPath(current);
                return;
            }

            foreach(Vector2Int dir in directions)
            {
                Vector2Int neighbor = dir + current;
                if (!map.ContainsKey(neighbor)) continue;
                int tentativeGScore = gScore[current] + 1;
                if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom.Add(neighbor, current);
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + heuristic(neighbor);
                    int neighborSetRep = convertVec2Int(neighbor);
                    if (!openSet.Contain(neighborSetRep)) openSet.Add(neighborSetRep);
                } 
            }
        }
    }

    public List<GridCube> ReconstructPath(Vector2Int current) {
        List<GridCube> res = new List<GridCube>() {map[current]};
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            res.Insert(0, map[current]);
        }
        return res;
    }

    //manhattan distance for four directions
    public int heuristic(Vector2Int coord)
    {
        return Math.Abs(endCube.getGridPos().x - coord.x) + Math.Abs(endCube.getGridPos().y - coord.y); 
    }

    public void loadMap()
    {
        var gridCubes = FindObjectsOfType<GridCube>();
        foreach (GridCube gridCube in gridCubes)
        {
            var gridPos = gridCube.getGridPos();
            if (map.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + gridCube);
            }
            else
            {
                map.Add(gridCube.getGridPos(), gridCube);
            }
        }
    }

    public void printMapKeys()
    {
        foreach (Vector2Int key in map.Keys)
        {
            print(key);
        }
    }

    private void printPath()
    {
        if (path == null) print("NO PATH FOUND");
        else
        {
            foreach (GridCube gc in path)
            {
                print(gc.getGridPos());
            }
        }
    }

    public int convertVec2Int(Vector2Int vec)
    {
        if (Math.Abs(vec.x) > 4999 || Math.Abs(vec.y) > 4999) throw new IndexOutOfRangeException();
        return (vec.x+5000) * 10000 + vec.y + 5000;
    }

    public Vector2Int convertInt2Vec(int num)
    {
        return new Vector2Int((num / 10000) % 10000 - 5000, num % 10000 - 5000);
    }
}



//from https://egorikas.com/max-and-min-heap-implementation-with-csharp/, modified by me
public class MinHeap
{
    private readonly int[] _elements;
    private int _size;

    public MinHeap(int size)
    {
        _elements = new int[size];
    }

    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
    private bool IsRoot(int elementIndex) => elementIndex == 0;

    private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
    private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
    private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }

    public bool Contain(int num)
    {
        foreach(int element in _elements)
        {
            if (element == num) return true;
        }
        return false;
    } 

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public int Peek()
    {
        if (_size == 0)
            throw new IndexOutOfRangeException();

        return _elements[0];
    }

    public int Pop()
    {
        if (_size == 0)
            throw new IndexOutOfRangeException();

        var result = _elements[0];
        _elements[0] = _elements[_size - 1];
        _size--;

        ReCalculateDown();

        return result;
    }

    public void Add(int element)
    {
        if (_size == _elements.Length)
            throw new IndexOutOfRangeException();

        _elements[_size] = element;
        _size++;

        ReCalculateUp();
    }

    private void ReCalculateDown()
    {
        int index = 0;
        while (HasLeftChild(index))
        {
            var smallerIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
            {
                smallerIndex = GetRightChildIndex(index);
            }

            if (_elements[smallerIndex] >= _elements[index])
            {
                break;
            }

            Swap(smallerIndex, index);
            index = smallerIndex;
        }
    }

    private void ReCalculateUp()
    {
        var index = _size - 1;
        while (!IsRoot(index) && _elements[index] < GetParent(index))
        {
            var parentIndex = GetParentIndex(index);
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World
{
    public int sizeX = 64;
    public int sizeY = 64;
    public int maxHeight = 255;
    public GameObject defaultBlock;
    public GameObject tree;

    private Block[,,] world;

    public World()
    {
        world = new Block[sizeX, sizeY, maxHeight];
    }

    public void Generate()
    {
        GameObject ground = new GameObject("World");

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                GameObject cube = GameObject.Instantiate(defaultBlock);
                cube.transform.position = new Vector3(x - (sizeX / 2), 0, y - (sizeY / 2));
                cube.transform.SetParent(ground.transform);
            }
        }

        GameObject.Instantiate(tree, new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public World world;

    void Start()
    {
        world.Generate();
    }

    void Update()
    {
        
    }
}

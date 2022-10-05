using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [Header("Block stats...")]
    public int id = -1;
    public float mineTime = 2f;
    public Texture blockTex;
    public Color blockColor = Color.white;

    [Header("Drop...")]
    public GameObject dropItem = null;
    [Range(0,9)]
    public int dropAmount = 1;
    public float dropPositionDeviation = 0.25f;

    private void Start()
    {
        if (dropItem == null)
        {
            dropItem = gameObject;
        }

        gameObject.GetComponent<Renderer>().material.SetTexture("_BlockTex", blockTex);
        gameObject.GetComponent<Renderer>().material.SetColor("_BlockColor", blockColor);
    }

    public virtual void Mine()
    {
        for(int i = 0; i < dropAmount; i++)
        {
            DropCollectible();
        }

        GameObject.Destroy(gameObject);
    }

    public void DropCollectible()
    {
        GameObject collectible = GameObject.CreatePrimitive(PrimitiveType.Cube);
        collectible.transform.position = transform.position + new Vector3(Random.Range(0f, dropPositionDeviation), 0, Random.Range(0f, dropPositionDeviation));

        BoxCollider trigger = collectible.AddComponent<BoxCollider>();
        trigger.isTrigger = true;
        trigger.size = new Vector3(5f, 5f, 5f);

        collectible.AddComponent<Rigidbody>();
        collectible.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        collectible.AddComponent<Collectible>();
        collectible.GetComponent<Collectible>().material = dropItem.GetComponent<Renderer>().sharedMaterial;
        collectible.GetComponent<Collectible>().material.SetTexture("_BlockTex", dropItem.GetComponent<Block>().blockTex);
        collectible.GetComponent<Collectible>().material.SetColor("_BlockColor", dropItem.GetComponent<Block>().blockColor);
        collectible.tag = "Collectible";
    }
}

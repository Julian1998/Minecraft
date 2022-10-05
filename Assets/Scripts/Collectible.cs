using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public Vector3 scale = new Vector3(0.2f, 0.2f, 0.2f);
    public Material material;

    private void Start()
    {
        transform.localScale = scale;

        if(material != null)
        {
            gameObject.GetComponent<MeshRenderer>().material = material;
        }
    }

    void Update()
    {
        transform.Rotate(0, 1 * rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Collectible") || collision.gameObject.tag.Equals("Player"))
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }
}

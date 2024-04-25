using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * 20 * Time.deltaTime);
    }
}

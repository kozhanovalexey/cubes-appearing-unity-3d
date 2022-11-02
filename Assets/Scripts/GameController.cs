using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float spawnPeriod;
    public float cubeSpeed;
    public float cubeDistanceDestroy;
    public GameObject cubesParent;
    private int maxSpawn = 100;
    private int nowSpawned = 0;
    DateTime lastSpawn;
    public GameObject cubePrefab;

    private void Start()
    {
        SetSpeedToCubes(cubeSpeed);
        lastSpawn = DateTime.Now;
    }

    void Update()
    {
        // Destroy all outraged cubes.
        for (int i = 0; i < cubesParent.transform.childCount; i++)
        {
            Transform cubeTransform = cubesParent.transform.GetChild(i);
            Vector3 cubePosition = cubeTransform.position;
            if (cubePosition.z > cubeDistanceDestroy)
            {
                Destroy(cubeTransform.gameObject);
                nowSpawned--;
            }
        }

        if (lastSpawn.AddSeconds(spawnPeriod) < DateTime.Now)
        {
            lastSpawn = DateTime.Now;
            if (nowSpawned < maxSpawn)
            {
                GameObject newCube = Instantiate(cubePrefab, cubesParent.transform);
                newCube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, cubeSpeed);
                nowSpawned++;
            }
        }
    }

    public void SetSpeedToCubes(float neededSpeed)
    {
        for (int i = 0; i < cubesParent.transform.childCount; i++)
        {
            Transform cubeTransform = cubesParent.transform.GetChild(i);
            Rigidbody rb = cubeTransform.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, neededSpeed);
        }
    }

    public void SetSpeedToCubesString(string speed)
    {
        cubeSpeed = float.Parse(speed);
        SetSpeedToCubes(cubeSpeed);
    }

    public void SetSpawnPeriodString(string period)
    {
        spawnPeriod = float.Parse(period);
    }

    public void SetCubeDistanceDestroyString(string distance)
    {
        cubeDistanceDestroy = float.Parse(distance);
    }
}

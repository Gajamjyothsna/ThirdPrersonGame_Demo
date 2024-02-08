using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSObjectSpawner : MonoBehaviour
{
    [SerializeField] List<TPSObject> objects;
    [SerializeField] List<Transform> positions;

    private void Start()
    {
        InstantiateObjects();
    }
    private void InstantiateObjects()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            int index = Random.Range(0, positions.Count);
            TPSObject obj = Instantiate(objects[index], positions[index]);
        }
       
    }
}

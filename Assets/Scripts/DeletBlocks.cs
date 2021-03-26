using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletBlocks : MonoBehaviour
{
    void Start()
    {
        GameObject block1 = GameObject.Find("Block1");
        Destroy(block1);

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("BLockToDelete");
    }
}

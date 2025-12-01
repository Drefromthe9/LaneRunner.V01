using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = true;

    int lastSegmentIndex = -1;

    //  How many segments you want to keep alive at once
    [SerializeField] int maxSegments = 8;

    //  Track spawned segments in order
    private Queue<GameObject> spawnedSegments = new Queue<GameObject>();

    void Start()
    {
        creatingSegment = true;
        StartCoroutine(SegmentGen());
    }

    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        int segmentNum = GetNextSegmentIndex();

        GameObject newSeg = Instantiate(
            segment[segmentNum],
            new Vector3(0, 0, zPos),
            Quaternion.identity
        );

        spawnedSegments.Enqueue(newSeg);   //  remember the new one

        //  If we have too many segments, delete the oldest
        if (spawnedSegments.Count > maxSegments)
        {
            GameObject oldSeg = spawnedSegments.Dequeue();
            if (oldSeg != null)
            {
                Destroy(oldSeg);
            }
        }

        zPos += 200;
        yield return new WaitForSeconds(3f);
        creatingSegment = false;
    }

    int GetNextSegmentIndex()
    {
        if (segment.Length == 1) return 0;

        int index;
        do
        {
            index = Random.Range(0, segment.Length);
        }
        while (index == lastSegmentIndex);

        lastSegmentIndex = index;
        return index;
    }
}



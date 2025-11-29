using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = true;

    int lastSegmentIndex = -1;

    void Start()
    {
        creatingSegment = true;
        StartCoroutine(SegmentGen());
    }

    void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        int segmentNum = GetNextSegmentIndex();
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
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
            index = Random.Range(0, segment.Length);  // use whole array
        }
        while (index == lastSegmentIndex);

        lastSegmentIndex = index;
        return index;
    }
}

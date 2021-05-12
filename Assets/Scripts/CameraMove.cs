using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    float xPlayerOffset, yPlayerOffset;
    Vector3 simPlayerPos;
    public float xOffset, yOffset;
    public float xMaxOffset, yMaxOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        simPlayerPos = playerPos.position;
        simPlayerPos += new Vector3(xOffset, yOffset, 0f);

        xPlayerOffset = this.transform.position.x - simPlayerPos.x;
        yPlayerOffset = this.transform.position.y - simPlayerPos.y;

        xPlayerOffset = Mathf.Clamp(xPlayerOffset, -xMaxOffset, xMaxOffset);
        yPlayerOffset = Mathf.Clamp(yPlayerOffset, -yMaxOffset, yMaxOffset);

        this.transform.position = new Vector3(simPlayerPos.x + xPlayerOffset, simPlayerPos.y + yPlayerOffset, this.transform.position.z);
    }
}

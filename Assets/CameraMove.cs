using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    float xPlayerOffset, yPlayerOffset;
    public float xOffset, yOffset;
    public float xMaxOffset, yMaxOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xPlayerOffset = this.transform.position.x - playerPos.position.x;
        yPlayerOffset = this.transform.position.y - playerPos.position.y;

        xPlayerOffset = Mathf.Clamp(xPlayerOffset, -xMaxOffset, xMaxOffset);
        yPlayerOffset = Mathf.Clamp(yPlayerOffset, -yMaxOffset, yMaxOffset);

        this.transform.position = new Vector3(playerPos.position.x + xPlayerOffset, playerPos.position.y + yPlayerOffset, this.transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;

    float xPlayerOffset, yPlayerOffset;
    Vector3 simPlayerPos;
    Camera cameraComponent;
    float xCamPos, yCamPos;
    float halfWidth, halfHeight, aspect;
    public float xOffset, yOffset;
    public float xMaxOffset, yMaxOffset;
    public float xPositiveLimit = 256f, xNegativeLimit = -15f, yPositiveLimit = 256f, yNegativeLimit = -256f;
    private float xCalculatedPositiveLimit, xCalculatedNegativeLimit, yCalculatedPositiveLimit, yCalculatedNegativeLimit;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        CalculateLimits();
    }

    // Update is called once per frame
    void Update()
    {
        if (aspect != cameraComponent.aspect || Input.GetKeyDown(KeyCode.F5)) // Detect change in camera
        {
            CalculateLimits();
        }

        simPlayerPos = playerPos.position;
        simPlayerPos += new Vector3(xOffset, yOffset, 0f);

        xPlayerOffset = this.transform.position.x - simPlayerPos.x;
        yPlayerOffset = this.transform.position.y - simPlayerPos.y;

        xPlayerOffset = Mathf.Clamp(xPlayerOffset, -xMaxOffset, xMaxOffset);
        yPlayerOffset = Mathf.Clamp(yPlayerOffset, -yMaxOffset, yMaxOffset);

        xCamPos = simPlayerPos.x + xPlayerOffset;
        yCamPos = simPlayerPos.y + yPlayerOffset;

        xCamPos = Mathf.Clamp(xCamPos, xCalculatedNegativeLimit, xCalculatedPositiveLimit);
        yCamPos = Mathf.Clamp(yCamPos, yCalculatedNegativeLimit, yCalculatedPositiveLimit);
        
        this.transform.position = new Vector3(xCamPos, yCamPos, this.transform.position.z);

    }

    void CalculateLimits()
    {
        aspect = cameraComponent.aspect;
        halfHeight = cameraComponent.orthographicSize;
        halfWidth = halfHeight * cameraComponent.aspect;

        xCalculatedPositiveLimit = xPositiveLimit - halfWidth;
        xCalculatedNegativeLimit = xNegativeLimit + halfWidth;

        yCalculatedPositiveLimit = yPositiveLimit - halfHeight;
        yCalculatedNegativeLimit = yNegativeLimit + halfHeight;

        Debug.Log("Height: " + halfHeight);
        Debug.Log("Width: " + halfWidth);
        Debug.Log("Max X: " + xCalculatedPositiveLimit);
        Debug.Log("Min X: " + xCalculatedNegativeLimit);
        Debug.Log("Max Y: " + yCalculatedPositiveLimit);
        Debug.Log("Min Y: " + yCalculatedNegativeLimit);

        Debug.Log(transform.position);
    }
}

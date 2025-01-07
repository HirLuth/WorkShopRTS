using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Speed Cam Values")]
    public float moveSpeed;
    public float zoomSpeed;
    public float minZoomDist;
    public float maxZoomDist;

    [SerializeField] private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);

        if(scrollInput > 0.0f && dist < minZoomDist)
        return;
        else if(scrollInput < 0.0f && dist > maxZoomDist)
        return;

        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
    }
}

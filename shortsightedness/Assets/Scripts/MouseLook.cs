using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float MouseSens = 100f;
    public Transform player;
    public Transform glass;
    public Transform reminder;
    public GlassController gc;
    public ValueController vc;
    float xRotation = 0f;
    int layerMask = 1 << 9;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10/*, layerMask*/))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (hitInfo.collider.tag == "Computer")
            {
                vc.Sight += vc.sightspeed * Time.deltaTime;
                if (vc.Sight >= vc.MaxSight) { vc.Sight = vc.MaxSight; }
                if (vc.WorkValue >= vc.TargetWork) { vc.WorkValue = vc.TargetWork; }
                vc.WorkValue += vc.workspeed * Time.deltaTime;
                reminder.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    gc.position = Random.Range(0, 0.5f);
                    gc.isDroped = false;
                    if (glass != null) { glass.gameObject.SetActive(false); }
                    reminder.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            reminder.gameObject.SetActive(false);
        }
        // reminder.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public GlassController gc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 5f;
            Camera.main.transform.position -= transform.up * Time.deltaTime * 1.2f;
            if (Camera.main.transform.localPosition.y < -0.5)
            {
                Camera.main.transform.localPosition = new Vector3(0, -0.5f, 0);
            }
        }
        else if(Camera.main.transform.localPosition.y < 1f)
        {
            Camera.main.transform.position += transform.up * Time.deltaTime * 1.2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl)) { speed = 10f; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * -20 + transform.forward * z;

        if (gc.isDroped) { speed = 4f; }
        else { speed = 10f; }
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

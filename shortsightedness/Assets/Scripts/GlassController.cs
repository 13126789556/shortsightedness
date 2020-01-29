using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassController : MonoBehaviour
{
    [Range(0,1)]
    public float position;

    public Material glasses;
    public Transform glass;
    public float fallrange;
    public bool isDroped = false;
    public Transform pushUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        glasses.SetTextureOffset("_AlphaTex", new Vector2(0, position));
        if (Input.GetKey(KeyCode.P) && position >= 0 && !isDroped)
        {
            position -= Time.deltaTime * 1f;
            if(position < 0) { position = 0; }
        }
        if (position >= 0.3 && !isDroped)
        {
            pushUI.GetComponent<Text>().text = "Press P to adjust your glasses";
            pushUI.gameObject.SetActive(true);
        }
        else if (isDroped)
        {
            pushUI.GetComponent<Text>().text = "Find your glasses!";
        }
        else
        {
            pushUI.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log(1);
            position += 0.35f;
            if(position >= 1 && !isDroped)
            {
                isDroped = true;
                float x = Random.Range(-fallrange, fallrange);
                //glass.position = this.transform.position + new Vector3(x, 0, x);
                glass.position = transform.position;
                glass.GetComponent<Rigidbody>().velocity = new Vector3(x, 0, x);
                glass.gameObject.SetActive(true);
            }
        }
    }
}

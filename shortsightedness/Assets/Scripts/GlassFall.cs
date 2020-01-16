using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GlassFall : MonoBehaviour
{
    public Transform glass;
    public float fallrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //TO DO : CODE ABOUT VISION;
        float x = Random.Range(-fallrange, fallrange);
   

        if (other.tag == "Obstacle") {
            glass.position = this.transform.position + new Vector3(x, 0, x);
            glass.gameObject.SetActive(true);
        }
    }

}

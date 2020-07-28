using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect;
     void OnTriggerEnter2D(Collider2D col)
    {

        
          if (col.tag == "shuraken")
        {
            Destroy(col.gameObject);
            Instantiate(effect, col.transform.position  , transform.rotation );
             FindObjectOfType<audio_manager>().Play("explose");
        }
    }
}

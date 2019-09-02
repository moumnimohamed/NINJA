using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
   /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   void Start()
   {
        
   }

   public void destroyThis(){
      if (transform.parent != null)
      Destroy(transform.parent.gameObject);
      Destroy(gameObject);
   }

public void desactiverGameobject(){
    this.gameObject.SetActive(false);
}
public void activerGameobject(){
    this.gameObject.SetActive(true);
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugMoveUpDown : MonoBehaviour
{
    // Start is called before the first frame update
   public int direction = 1; //int direction where 0 is stay, 1 up, -1 down
public int top = 3;
public int bottom = -3;

public float speed = 5;


void Update ()
{
if (transform.position.y >= top)
direction = -1;

if (transform.position.y <= bottom)
direction = 1;

transform.Translate(0, speed * direction * Time.deltaTime, 0);
} 
}

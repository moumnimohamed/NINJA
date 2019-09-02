using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBackround : MonoBehaviour
{
    
public float  backgroundSize;
public float paralaxSpeed;
private Transform cameratransform;
private Transform[] layers;
private float viewzone=10;
private int leftIndex;
private int rightndex;
private float lastCameraX;

	// Use this for initialization
	void Start () {
 cameratransform= Camera.main.transform;
 lastCameraX=cameratransform.position.x;
		layers= new Transform[transform.childCount];
		for(int i=0 ;i< transform.childCount;i++)
		layers[i]=transform.GetChild(i);

		leftIndex=0;
		rightndex=layers.Length-1;
	layers[0].position =new Vector2(transform.position.x,transform.position.y);
	layers[1].position =new Vector2(transform.position.x,transform.position.y);
	layers[2].position =new Vector2(transform.position.x,transform.position.y);
		

	}

	private void scrollLeft(){
		//int lastright  = rightndex;
		layers[rightndex].position =new Vector3(layers[leftIndex].position.x-backgroundSize,layers[leftIndex].position.y ,layers[leftIndex].position.z);
		
		leftIndex=rightndex;
		rightndex--;
		if(rightndex<0)
		rightndex=layers.Length-1;
	}

		private void scrollright(){
	//	int lastright  = leftIndex;
		layers[leftIndex].position =new Vector3 (layers[rightndex].position.x+backgroundSize,layers[rightndex].position.y,layers[rightndex].position.z);
		rightndex=leftIndex;
		leftIndex++;
		if(leftIndex == layers.Length)
		leftIndex=0;

	}
	
	// Update is called once per frame
	void Update () {
		float deltaX=cameratransform.position.x-lastCameraX;
		transform.position+=Vector3.right*(deltaX*paralaxSpeed);
		lastCameraX=cameratransform.position.x;
		if(cameratransform.position.x< (layers[leftIndex].transform.position.x+viewzone))
		          scrollLeft();
				  if(cameratransform.position.x> (layers[rightndex].transform.position.x-viewzone))
		          scrollright();


				  
	}
}

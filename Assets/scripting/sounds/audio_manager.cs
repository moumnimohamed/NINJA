using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class audio_manager : MonoBehaviour {

	public sound [] Sounds;
public static audio_manager instance;
	void Awake()
	{
		if(instance==null)
		instance=this;
		else{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		foreach(sound s in Sounds){
			s.source =gameObject.AddComponent<AudioSource>();
			s.source.clip=s.clip;
			s.source.volume =s.volume;
			s.source.loop=s.loop;
		}	
//backround music
     this.Play("japanMusic");
	}
    
	public void Play (string name){
	sound s=	Array.Find (Sounds,sound=>sound.name==name);
	if(s==null){
		Debug.LogWarning("sound: "+ name +" dosnt found");
		return;
	}else{
	s.source.Play();
	}
}

public void stop (string name){
	sound s=	Array.Find (Sounds,sound=>sound.name==name);
	if(s==null){
		Debug.LogWarning("sound: "+ name +" dosnt found");
		return;
	}else{
	s.source.Stop();
	}
}

}
using UnityEngine;
using System.Collections;

public class PlayLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		MovieTexture movie = renderer.material.mainTexture as MovieTexture;
		audio.clip = movie.audioClip;
		
		audio.Play();
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

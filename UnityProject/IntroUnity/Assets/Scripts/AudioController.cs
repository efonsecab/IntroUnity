using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
    public AudioSource AudioSource { get; set; }
	// Use this for initialization
	void Start () {
        this.AudioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

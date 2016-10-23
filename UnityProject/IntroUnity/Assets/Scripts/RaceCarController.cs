using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RaceCarController : MonoBehaviour
{
    private Vector3 OriginalPosition;
    private Quaternion OriginalRotation;
    public int CurrentSpeed = 0;
    public int CurrentGear = 1;
    private int TotalGears = 5;
    public int Energy = 100;
    private Rigidbody _rigidBody = null;
    public AudioSource AudioSource = null;
    public AudioClip CurrentClip = null;
    private AudioClip AudioClip_TheRush = null;
    public int Lap = 0;

    // Use this for initialization
    void Start()
    {
        this.OriginalPosition = this.transform.position;
        this.OriginalRotation = this.transform.rotation;
        this.AudioSource = GetComponent<AudioSource>();
        this._rigidBody = GetComponent<Rigidbody>();
        this.AudioClip_TheRush = Resources.Load<AudioClip>(@"Music\The Rush");
        this.CurrentClip = this.AudioClip_TheRush;
        this.AudioSource.clip = this.CurrentClip;
        this.AudioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            int newSpeed = CurrentSpeed + 1;
            var maxSpeedForCurrentGear = CurrentGear * 20;
            if (newSpeed > maxSpeedForCurrentGear && CurrentGear < TotalGears)
                CurrentGear += 1;
            if (newSpeed <= maxSpeedForCurrentGear)
                CurrentSpeed = newSpeed;
        }
        else
        {
            if (CurrentSpeed > 0)
                CurrentSpeed = CurrentSpeed - 1;
        }
        if (CurrentSpeed > 0)
        {
            if (!this.AudioSource.isPlaying)
                this.AudioSource.Play();
            else
            {
                this.AudioSource.UnPause();
            }
            var step = CurrentSpeed * Time.deltaTime;
            var forward = this.transform.right;
            //Debug.Log(forward);
            var newTarget = this.transform.position + forward;
            //Debug.Log("New Position: " + newTarget);
            this.transform.position = Vector3.MoveTowards(this.transform.position, newTarget, step);
        }
        else
        {
            if (this.AudioSource.isPlaying)
                this.AudioSource.Pause();
        }
        //if (_rigidBody.velocity.y >= 0)
        {
            var h = Input.GetAxis("Horizontal");
            if (h != 0)
            {
                this.transform.Rotate(new Vector3(0, h, 0));
            }
        }
        if (transform.position.y < -10)
        {
            this.CurrentGear = 1;
            this.CurrentSpeed = 0;
            this.transform.position = OriginalPosition;
            this.transform.rotation = OriginalRotation;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit: " + other.gameObject);
        if (other.gameObject.name == "FinishLine")
        {
            Debug.Log("New Lap!");
            Lap += 1;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dangerous")
        {
            this.Energy -= 5;
        }
    }
}

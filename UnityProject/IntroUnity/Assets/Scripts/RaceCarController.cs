using UnityEngine;
using System.Collections;

public enum PlayerIdentifier
{
    Player1,
    Player2
}

public class RaceCarController : MonoBehaviour
{
    public PlayerIdentifier Player = PlayerIdentifier.Player1;
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
    public AudioController AudioController = null;

    // Use this for initialization
    void Start()
    {
        this.OriginalPosition = this.transform.position;
        this.OriginalRotation = this.transform.rotation;
        this.AudioController = GameObject.FindObjectOfType<AudioController>();
        this.AudioSource = this.AudioController.GetComponent<AudioSource>();
        this._rigidBody = GetComponent<Rigidbody>();
        this.AudioClip_TheRush = Resources.Load<AudioClip>(@"Music\The Rush");
        this.CurrentClip = this.AudioClip_TheRush;
        if (!this.AudioSource.isPlaying)
        {
            this.AudioSource.clip = this.CurrentClip;
            this.AudioSource.loop = true;
            this.AudioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float v = 0;
        float h = 0;
        switch (this.Player)
        {
            case PlayerIdentifier.Player1:
                h = Input.GetAxis("Horizontal_Keyboard");
                v = Input.GetAxis("Vertical_Keyboard");
                break;
            case PlayerIdentifier.Player2:
                h = Input.GetAxis("Horizontal_Joystick1");
                v = Input.GetAxis("Vertical_Joystick1");
                break;
        }
        if (v > 0)
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
            var step = CurrentSpeed * Time.deltaTime;
            var forward = this.transform.right;
            //Debug.Log(forward);
            var newTarget = this.transform.position + forward;
            //Debug.Log("New Position: " + newTarget);
            this.transform.position = Vector3.MoveTowards(this.transform.position, newTarget, step);
        }
        //else
        //{
        //    if (this.AudioSource.isPlaying)
        //        this.AudioSource.Pause();
        //}
        //if (_rigidBody.velocity.y >= 0)
        {
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

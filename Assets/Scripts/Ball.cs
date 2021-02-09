using UnityEngine;

public class Ball : MonoBehaviour{

    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    int screenMidPoint = 8;
    [SerializeField] float randomFactor;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start(){
        //calculates the distance between the ball and the paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);

            //if the player is on the left side of the screen the ball shoots to the left side
            //else the player is on the right side of the screen and shoots the ball to the right side
            if (transform.position.x < screenMidPoint) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-xPush, yPush);
            } else {
                GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            }
        }
    }

    private void LockBallToPaddle() {
        //position of the paddle
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        //sets the ball position in the offset of the paddle position
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0.0f, randomFactor), 
            Random.Range(0.0f, randomFactor));

        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}


using UnityEngine;

public class ball : MonoBehaviour {

    [SerializeField] pixel paddle1;
    bool hasStarted = false;
    
    [SerializeField]float min;
    [SerializeField] float Max;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddletoBallVector;
    Rigidbody2D myrigidbody;

	// Use this for initialization
	void Start ()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        myrigidbody=GetComponent<Rigidbody2D>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (hasStarted==false)
        {
            launchtheball();
            locktheballonpaddle();
        }

    }

    

    private void launchtheball()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            myrigidbody.velocity = new Vector2(min, Max);
            hasStarted = true;
        }
    }

    private void locktheballonpaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddletoBallVector + paddlePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 balldeflection = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted == true)
        {
            myrigidbody.velocity += balldeflection;
            GetComponent<AudioSource>().Play();
        }
    }

}


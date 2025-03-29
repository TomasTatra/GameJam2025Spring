using UnityEngine;

public class Clouding : MonoBehaviour
{
    int speed;
    int leftSide = -55;
    int RightSide = 55;
    int goRight;

    private void Awake()
    {
        Regenerate();
    }

    void Regenerate()
    {
        speed = Random.Range(1, 4);
        goRight = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    void Update()
    {
        transform.position += new Vector3(1, 0, 0 ) * Time.deltaTime * speed * goRight;
        if (transform.position.x > RightSide) 
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
            Regenerate();
        }
        if (transform.position.x < leftSide)
        {
            transform.position = new Vector3(RightSide, transform.position.y, transform.position.z);
            Regenerate();
        }
    }
}

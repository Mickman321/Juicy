using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField, Range(1, 160)]
    float speed;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right) && transform.position.x < 69)
        {
            // den h�r koden flyttar spelaren till den position som beffiner sig i x.
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            print("Hej Mickael");
        }
        if (Input.GetKey(left)&& transform.position.x > -69)
        {
            // Den h�r koden startar en animation n�r spelarens position �r mot x och hastighet �ver noll.
           
            // den h�r koden flyttar spelaren till den position som beffiner sig i -x.
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            print("Hej Mickael");
        }
        if (Input.GetKey(up))
        {
            // den h�r koden flyttar spelaren till den position som beffiner sig i x.
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            print("Hej Mickael");
        }
        if (Input.GetKey(down))
        {
            // Den h�r koden startar en animation n�r spelarens position �r mot x och hastighet �ver noll.

            // den h�r koden flyttar spelaren till den position som beffiner sig i -x.
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            print("Hej Mickael");
        }
    }
}

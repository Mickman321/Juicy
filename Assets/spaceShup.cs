using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceShup : MonoBehaviour
{
    public Text ScoreText;
    public enum Typ { Skepp, Alien, Skott, Bomb}
    public Typ typ;
    public GameObject[] prefabs;
    public GameObject[] punkteer;
    public int vapen = 0;
    public static int score;
    public float max;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            vapen++;
            if (vapen > 2)
            {
                vapen = 0;
            }
        }
        ScoreText.text = "Score: " + score;
        switch (typ)
        {
            case Typ.Skepp:
                if (Input.GetKeyUp(KeyCode.Space) && vapen == 0)
                {
                    print("bang");
                    Instantiate(prefabs[0], transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(0, 0, 500);
                }
                if (Input.GetKeyUp(KeyCode.Space) && vapen == 2)
                {
                    print("bang");
                    Instantiate(prefabs[1], transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(0, 0, 500);
                }
                int rng = Random.Range(0, 3);
                if (timer > 5)
                {
                    print("Ahh");
                    timer = 0;
                    Instantiate(prefabs[2], punkteer[rng].transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(0, 0, -250);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody>().AddForce(5, 0, 0);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    GetComponent<Rigidbody>().AddForce(-50, 0, 0);
                }
                if (transform.position.x > max)
                {
                    transform.position = new Vector3(-max, 0, 0);
                }
                if (transform.position.x < -max)
                {
                    transform.position = new Vector3(max, 0, 0);
                }
                timer += Time.deltaTime;
                break;
            case Typ.Alien:
                break;
            case Typ.Skott:
                break;
            case Typ.Bomb:
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    GetComponent<SphereCollider>().radius = 4;
                    Destroy(gameObject, 1);
                }
                break;
            default:
                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (typ)
        {
            case Typ.Skepp:
                if (collision.transform.gameObject.layer == 6)
                {
                    Destroy(gameObject);
                }
                break;
            case Typ.Alien:
                if (collision.transform.gameObject.layer == 7)
                {
                    score++;
                    Destroy(gameObject);
                }
                break;
            case Typ.Skott:
                break;
            case Typ.Bomb:
                break;
            default:
                break;
        }
    }
}

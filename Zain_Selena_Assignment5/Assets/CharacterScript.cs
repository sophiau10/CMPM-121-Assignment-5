using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public float movementSpeed = 10;
    public float rotationSpeed = 5;
    public float smooth = 1f;
    private Vector3 targetAngles;
    public Text countText;
    private int count=0;
    public GameObject door;
    public GameObject door2;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }
    /*public ParticleSystem explosion;

    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quartenion.identity);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("We have hit " + other.name);
        Instantiate(particles, transform.position, transform.rotation);
        Destroy(other.gameObject);
        count = count + 1;
        SetCountText();
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        //move and rotate
        if (Input.GetKey(KeyCode.D))
        {
            targetAngles = transform.eulerAngles + 180f * Vector3.up;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, Time.deltaTime);
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            //GetComponent<Animator>().SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetAngles = transform.eulerAngles - 180f * Vector3.up;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, Time.deltaTime);
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            //GetComponent<Animator>().SetBool("Moving", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        //idle
        if(!Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Moving", false);
        }
        //open door
        if(count==5)
        {
            door.GetComponent<Animator>().SetBool("isOpen", true);
        }
        if (count == 10)
        {
            door2.GetComponent<Animator>().SetBool("isOpen", true);
        }
        if(count ==15)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}

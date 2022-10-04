using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject explod;
    private int count;
    private Rigidbody rd;
    private Vector2 vector2;
    public GameObject winText;
    public TextMeshProUGUI countText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rd = GetComponent<Rigidbody>();
    }


    private void OnMove(InputValue inputValue)
    {
        vector2 = inputValue.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rd.AddForce(vector2.x, 0, vector2.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            explod.transform.position = transform.position;
            explod.SetActive(true);
            Instantiate(explod);
            count++;
            other.gameObject.SetActive(false);

            countText.SetText("Count is " + count);

            if(count >= 5)
            {
                winText.SetActive(true);
                player.SetActive(false);
            }
        }
        
    }
}

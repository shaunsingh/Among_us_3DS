using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class costumize_controller : MonoBehaviour {

    public GameObject toEnable;

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "lobbyLaptop")
        {
            Debug.Log("enter computer");

            toEnable.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "lobbyLaptop")
        {
            Debug.Log("exit computer");

            toEnable.SetActive(false);
        }
    }
}

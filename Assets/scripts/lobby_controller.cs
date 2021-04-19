using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lobby_controller : MonoBehaviour {

	public void startGame()
    {
        SceneManager.LoadScene("mode");
    }
}

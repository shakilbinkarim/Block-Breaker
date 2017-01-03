using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour
{

    static MusicPlayerScript instance = null;

	// Is called before Start Method
	void Awake ()
	{
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}

	// Update is called once per frame
	void Update ()
	{

	}
}

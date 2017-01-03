using UnityEngine;
using System.Collections;

public class LoseColliderScript : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadLevel("Lose");
    }

}

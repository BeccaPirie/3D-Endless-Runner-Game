using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject character;
    public static bool isAsteriodFalling = false;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character");
    }

    void Update()
    {
        // drop asteroids when playing game
        if (CharacterMove.move && !isAsteriodFalling)
        {
            isAsteriodFalling = true;
            StartCoroutine(InstantiateAsteroids());
        }
    }

    // instantiate asteroid prefabs
    IEnumerator InstantiateAsteroids()
    {
        float time = Random.Range(5f, 10f);
        float x = Random.Range(-5f, 4.5f);
        float y = Random.Range(13f, 15f);
        float z = Random.Range(5f, 20f);

        // set time interval between asteroids
        yield return new WaitForSeconds(time);
        // drop asteroids on the course infront of the player
        Instantiate(asteroid, new Vector3(x, y, character.transform.position.z + z), Quaternion.identity);
        isAsteriodFalling = false;
    }
}

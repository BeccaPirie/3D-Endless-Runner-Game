using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    
    public GameObject projectile;
    public int power;

    void Start()
    {
        power = 1000;
    }

    void Update()
    {
        GameObject character = this.gameObject;
        GameObject obj;
        Rigidbody rb;

        // if powerup is activated add controls to use it
        if (CharacterMove.move && PowerUpTrigger.isPowerupActivated)
        {
            // instantiate projectile infront of player and throw forward
            if (Input.GetKeyDown(KeyCode.Space)) {
                obj = Instantiate(projectile, character.transform.position + (transform.forward * 1), Quaternion.identity);
                rb = obj.AddComponent(typeof(Rigidbody)) as Rigidbody;
                rb.AddRelativeForce(character.transform.forward.normalized * power);
            }
        }
    }
}

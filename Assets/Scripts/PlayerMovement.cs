using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private float shot_cooldown = 0.5f;
    private float speed = 0.2f;
    private bool cooldown = false;
    private float maxHorizontalDisplacement = 10.75f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check bounderies 14.5
        if (transform.position.x > -maxHorizontalDisplacement && transform.position.x < maxHorizontalDisplacement)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, 0);
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
        }
        if (transform.position.x <= -maxHorizontalDisplacement)
            transform.position = new Vector3(-maxHorizontalDisplacement + 0.05f, transform.position.y, 0);
        else if (transform.position.x >= maxHorizontalDisplacement)
            transform.position = new Vector3(maxHorizontalDisplacement - 0.05f, transform.position.y, 0);

        if (Input.GetKey(KeyCode.Space) && !cooldown)
        {
            Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 1f, 0), Quaternion.Euler(0, 0, 90));
            Invoke("ResetCooldown", shot_cooldown);
            cooldown = true;
        }
    }
    public void SetShotCooldown(float cooldown)
    {
        shot_cooldown = cooldown;
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}

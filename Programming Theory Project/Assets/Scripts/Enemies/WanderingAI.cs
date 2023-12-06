using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    private float obstacleRange = 5.0f;
    private bool _alive;

    [SerializeField] protected GameObject fireballPrefab;
    protected GameObject _fireball;

    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        RunAndShootAtPlayer(Movement, Shootfireball);
    }

    // Abstraction
    protected virtual void RunAndShootAtPlayer(Action movement, Action shootfireball )
    {
        if (_alive)
        {
            movement();

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        // Abstraction
                        shootfireball();
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = UnityEngine.Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }

    }


    // Abstraction
    protected virtual void Shootfireball()
    {
        _fireball = Instantiate(fireballPrefab) as GameObject;
        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
        _fireball.transform.transform.rotation = transform.rotation;
    }

    protected virtual void Movement()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}

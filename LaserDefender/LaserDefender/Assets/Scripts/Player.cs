using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] private float padding = 1f;

    [Header("Shoot")] 
    [SerializeField] private GameObject simple_laser;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectFiringPeriod = 0.1f;

    private Coroutine firingCoroutine;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;   
    
    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(fireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
           StopCoroutine(firingCoroutine); 
        }
    }

    IEnumerator fireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(simple_laser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectFiringPeriod);
        }
    }

    private float GetGameSpeed()
    {
        return moveSpeed * Time.deltaTime;
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * GetGameSpeed();
        float deltaY = Input.GetAxis("Vertical") * GetGameSpeed();
        
        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);
         
        transform.position = new Vector2(newXPos, newYPos);
    }
}

using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public InputAction moveAction;
    public InputAction shootAction;
    public float xRange = 10;

    public GameObject foodPrefab;

    private void Awake()
    {
      moveAction = InputSystem.actions.FindAction("Move");
      shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
        var Hinput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Hinput * speed * Time.deltaTime * Vector3.right);
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if (shootAction.triggered)
        {
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
        } 
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //zmos.DrawWireSphere(transform.position, 1);
        //zmos.color = Color.green;
        //zmos.DrawLine(transform.position,Camera.main.transform.position);
        Gizmos.DrawLine(new Vector3(-xRange, transform.position.y, transform.position.z),
            new Vector3(xRange, transform.position.y, transform.position.z));
    }
}


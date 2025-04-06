using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 5f;
    public float arrowRotateSpeed = 90f; 
    public Animator anm;
    private Vector3 targetPosition;
    private bool isMoving = false;
    void Start()
    {
        anm = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        HandleMouseMovement();
        HandleArrowKeyRotation();
    }
    void HandleMouseMovement()
    {  // using  raycast &  to check  mouse moves
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            string objName = hitObj.name;

            if (IsValidObject(objName))
            {
                targetPosition = hit.point;

                if (!isMoving && anm != null)
                {
                    anm.Play("Walking");
                }

                isMoving = true;
            }
        }

        if (isMoving)
        {    // players moving  logic  when mouse over 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Vector3 direction = (targetPosition - transform.position).normalized;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {  //  rotation logic  
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
            {   // player  stop 
                isMoving = false;

                if (anm != null)
                {
                    anm.Play("Idle");
                }
            }
        }
    }

    void HandleArrowKeyRotation()
    {     // keyboard input for rotate player 
        float horizontal = Input.GetAxis("Horizontal");    // Left/Right arrow or A/D keys
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            transform.Rotate(Vector3.up, horizontal * arrowRotateSpeed * Time.deltaTime);
        }
    }

    bool IsValidObject(string name)
    {      //  checking  all  object name 
        return name.Contains("Cube") || name.Contains("Sphere") ||
               name.Contains("Capsule") || name.Contains("Cylinder");
    }
}

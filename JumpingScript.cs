using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpAmount = 10;
    public float range = 1f;
    public bool grounded = false;
    public Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ShootRaycast();

        if(Input.GetKeyDown(KeyCode.Space) & grounded == true)
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }

    void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(JumpBool());
            }
        }
    }

    IEnumerator JumpBool()
    {
        grounded = true;
        yield return new WaitForSeconds(0.1f);
        grounded = false;
    }
}

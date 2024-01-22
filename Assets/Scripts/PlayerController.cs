using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float jumpStrength = 1;
    [SerializeField, ReadOnly]
    private bool touching;

    private CharacterController cc;
    private float verticalVelocity;

    void Start() {
        cc = GetComponent<CharacterController>();
        Debug.Log("Scale:" + Time.timeScale);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Cancel"))
            GameManager.instance.Cancel();
        MoveInput();
    }
    private void MoveInput() {
        touching = cc.isGrounded;
        if (cc.isGrounded) {
            verticalVelocity = -0.5f;
            if (Input.GetButtonDown("Jump")) {
                verticalVelocity = jumpStrength;
            }
        } else verticalVelocity += -gravity * Time.deltaTime;

        float hInput = Input.GetAxis("Horizontal");
        float fInput = Input.GetAxis("Vertical");

        // Move Vector
        Vector3 moveInput = new Vector3(hInput, 0, fInput).normalized * speed * Time.deltaTime
            + Vector3.up * verticalVelocity; // + gravity
        
        // Jump Impulse
        
        cc.Move(moveInput);
    }
}

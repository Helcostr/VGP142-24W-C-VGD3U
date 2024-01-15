using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float jumpSpeed = 10.0f;

    private CharacterController cc;

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Cancel"))
            GameManager.instance.Cancel();
        MoveInput();
    }
    private void MoveInput() {
        float hInput = Input.GetAxis("Horizontal");
        float fInput = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(hInput, 0, fInput).normalized;

        moveInput.y = cc.velocity.y;
        moveInput.y -= gravity * Time.deltaTime;
        moveInput *= Time.deltaTime;

        cc.Move(moveInput);
    }
}

using UnityEngine;

public class MainGameEngine : MonoBehaviour
{

    private InputMapping playerInput;
    private float moveInput;
    private Camera myCamera;
    public int[] widthOfGame = new int[2];
    [SerializeField] float speed = 0.2f;

    //InputAction leftRight;
    private void Awake()
    {
        myCamera = Camera.main;
        playerInput = new InputMapping();
        playerInput.Player.Scroll.performed += ctx => moveInput = ctx.ReadValue<float>();
        playerInput.Player.Scroll.canceled += ctx => moveInput = 0;
    }

    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    void Start()
    {
        //leftRight = InputSystem.actions.FindAction("LeftRight");
    }

    void Update()
    {
        //int go = leftRight.ReadValue<int>();
        //camera.transform.position -= new Vector3(moveInput, 0, 0);
        if (moveInput != 0)
            MoveCamera(moveInput);
    }

    void MoveCamera(float input)
    {

        if ((input < 0 && myCamera.transform.position.x > widthOfGame[0]) ||
            (input > 0 && myCamera.transform.position.x < widthOfGame[1]))
        {
            myCamera.transform.position += speed * new Vector3(moveInput, 0, 0);
        }
    }

    //double EaseInOutCubic(double x) {
    //    return x< 0.5 ? 4 * x* x* x : 1 - Math.Pow(-2 * x + 2, 3) / 2;
    //}
}

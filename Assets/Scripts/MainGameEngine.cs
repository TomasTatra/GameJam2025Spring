using UnityEngine;

public class MainGameEngine : MonoBehaviour
{

    InputMapping playerInput;
    float moveInput;
    double evolution = 0;
    int actualStep = 0;
    [SerializeField] GameObject[] animators;
    [SerializeField] int[] widthOfGame = new int[2];
    [SerializeField] double[] evolutionSteps = new double[5];
    [SerializeField] float speed = 0.2f;

    private void Awake()
    {
        playerInput = new InputMapping();
        playerInput.Player.Scroll.performed += ctx => moveInput = ctx.ReadValue<float>();
        playerInput.Player.Scroll.canceled += ctx => moveInput = 0;
    }

    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    void Start() {}

    void Update()
    {
        if (moveInput != 0)
            MoveCamera(moveInput);
    }

    void MoveCamera(float input)
    {

        if ((input < 0 && transform.position.x > widthOfGame[0]) ||
            (input > 0 && transform.position.x < widthOfGame[1]))
        {
            transform.position += speed * new Vector3(moveInput, 0, 0);
            Evolve(0.2);
        }
    }

    void Evolve(double by)
    {
        evolution += by;
        if (actualStep >= evolutionSteps.Length)
            return;
        if (evolution > evolutionSteps[actualStep])
        {
            actualStep++;
            foreach (var animator in animators)
            {
                animator.GetComponent<Animator>().SetInteger("stage", actualStep);
            }
        }
    }
}

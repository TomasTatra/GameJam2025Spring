using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class RandomWalk : Node
{
    private Transform characterTransform;

    private float waitTime = 3;
    private float waitCounter;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public RandomWalk() : base() { }
    public RandomWalk(Transform transform) : base()
    {
        characterTransform = transform;
        waitCounter = waitTime;
        animator = characterTransform.gameObject.GetComponent<Animator>();
        spriteRenderer = characterTransform.gameObject.GetComponent<SpriteRenderer>();
    }
    public override NodeState Evaluate()
    {
        Vector2 objectPosition;
        if (waitCounter > waitTime)
        {
            float limit = (float) Root.GetData("WalkingDistance");
            objectPosition = new Vector2(Random.Range(-limit, limit), characterTransform.position.y);
            Root.SetData("objectPosition", objectPosition);
            waitCounter = 0;
        }

        if (Root.GetData("objectPosition") == null)
        {
            waitCounter += Time.deltaTime;

            state = NodeState.FAILURE;
            return state;
        }
        objectPosition = (Vector2)Root.GetData("objectPosition");

        float speed = Vector2.Distance(objectPosition, characterTransform.position);
        animator.SetFloat("Speed", speed);
        if (speed < 0.001)
        {
            Root.ClearData("objectPosition");
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            spriteRenderer.flipX =  (characterTransform.position.x - objectPosition.x >= 0) ? true : false;
        }

        characterTransform.position = Vector2.MoveTowards(characterTransform.position, objectPosition, (float)Root.GetData("VillagerSpeed") * Time.deltaTime);

        state = NodeState.RUNNING;
        return state;
    }
}
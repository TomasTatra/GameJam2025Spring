using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{

    public static EventSystemManager Instance { get; private set; }

    public UnityEvent<int> OnEvolution;

    public UnityEvent<string> OnEventCalled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Villager : MonoBehaviour
{
    private float health = 100;
    
    private float currentHealth;
    [SerializeField]
    private float _healthLosePercentage = 0.05f;
   
    public UnityEvent<float> OnHealthChanged;


    private float delay = 0.5f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = delay;
        //EventSystemManager.Instance.OnThunderCalled.AddListener(HandleOnThunderCalled);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            currentHealth -= health * _healthLosePercentage;
            time = delay;
            OnHealthChanged?.Invoke(currentHealth / health);
        }
    }

    private void HandleOnThunderCalled()
    {

    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}

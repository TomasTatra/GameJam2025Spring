using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealthBar(float health)
    {
        gameObject.GetComponent<Slider>().value = health;
    }
}

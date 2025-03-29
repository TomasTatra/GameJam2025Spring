using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : MonoBehaviour
{

    [Serializable]
    struct PhaseButtons
    {
        [SerializeField]
        public Button[] _buttons;

    };

    [SerializeField]
    private PhaseButtons[] _phaseButtons;

    // Start is called before the first frame update
    void Start()
    {
        EventSystemManager.Instance.OnEvolution.AddListener(HandleOnEvolution);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleOnEvolution(int evolutionStage)
    {
        if (_phaseButtons[evolutionStage]._buttons != null)
        {
            foreach (Button buttons in _phaseButtons[evolutionStage]._buttons)
            {
                buttons.interactable = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManagerScript : MonoBehaviour
    {
        [SerializeField] private GameObject[] UIObjects;
        [SerializeField] private GameObject[] objectiveObjects;
        [SerializeField] private GameObject[] MenuObjects;
        [SerializeField] private int menuLayer;
        
        
        void Start()
        {
            
        }

        void ClosingMenus(GameObject _menu)
        {
            
            menuLayer--;
        }

        void OpeningMenus(GameObject _menu)
        {
            menuLayer++;
        }
        
        void Update()
        {
            //UIObjects[0].
            
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    ClosingMenus(MenuObjects[menuLayer]);
            //} 
        }
    }
}   

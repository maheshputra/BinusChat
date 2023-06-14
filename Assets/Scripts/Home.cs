using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BinusChat
{
    public class Home : MonoBehaviour
    {
        [Header("Recent Chat")]
        [SerializeField] private GameObject recentChat;

        [Header("Button")]
        [SerializeField] private Button homeButton;

        private void Start()
        {
            homeButton.onClick.AddListener(ShowHome);
        }

        public void UpdateRecentChat(){
            
        }

        private void ShowHome()
        {

        }
    }
}
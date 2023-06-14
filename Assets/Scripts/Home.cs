using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BinusChat
{
    public class Home : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private Button buttonHome;
        [SerializeField] private Button buttonChatList;
        [SerializeField] private Button buttonCallList;
        [SerializeField] private Button buttonNotification;

        [Header("Color")]
        [SerializeField] private Color colorWhite;
        [SerializeField] private Color colorBlue;
        [SerializeField] private Color colorLightBlue;

        [Header("Button Color")]
        [SerializeField] private Image imageButtonHomeBackground;
        [SerializeField] private Image imageButtonHomeIcon;
        [SerializeField] private Image imageButtonChatList;
        [SerializeField] private Image imageButtonCallList;

        [Header("Panel")]
        [SerializeField] private GameObject panelHome;
        [SerializeField] private GameObject panelChatList;
        [SerializeField] private GameObject panelCallList;

        private void Start()
        {
            buttonHome.onClick.AddListener(ShowHome);
            buttonChatList.onClick.AddListener(ShowChatList);
            buttonCallList.onClick.AddListener(ShowCallList);
            ShowHome();
        }

        private void ShowHome()
        {
            UpdateNavigationButtonHome(true);
            UpdateNavigationButton(imageButtonChatList, false);
            UpdateNavigationButton(imageButtonCallList, false);

            panelHome.SetActive(true);
            panelChatList.SetActive(false);
            panelCallList.SetActive(false);
        }

        private void ShowChatList()
        {
            UpdateNavigationButtonHome(false);
            UpdateNavigationButton(imageButtonChatList, true);
            UpdateNavigationButton(imageButtonCallList, false);
            
            panelHome.SetActive(false);
            panelChatList.SetActive(true);
            panelCallList.SetActive(false);
        }

        private void ShowCallList()
        {
            UpdateNavigationButtonHome(false);
            UpdateNavigationButton(imageButtonChatList, false);
            UpdateNavigationButton(imageButtonCallList, true);
            
            panelHome.SetActive(false);
            panelChatList.SetActive(false);
            panelCallList.SetActive(true);
        }

        public void UpdateNavigationButtonHome(bool selected)
        {
            if (selected)
            {
                imageButtonHomeBackground.color = colorWhite;
                imageButtonHomeIcon.color = colorBlue;
            }
            else
            {
                imageButtonHomeBackground.color = colorBlue;
                imageButtonHomeIcon.color = colorWhite;
            }
        }

        public void UpdateNavigationButton(Image icon, bool selected)
        {
            if (selected)
            {
                icon.color = colorBlue;
            }
            else
            {
                icon.color = colorLightBlue;
            }
        }
    }
}
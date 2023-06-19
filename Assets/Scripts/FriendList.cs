using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    public class FriendList : MonoBehaviour
    {
        public static FriendList instance;


        [Header("Settings")]
        [SerializeField] private List<FriendSO> friendSOs;
        [SerializeField] private FriendCard friendCardPrefab;

        [Header("UI")]
        [SerializeField] private GameObject friendPanel;
        [SerializeField] private Transform contentParent;

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        private void Start()
        {
            ShowPanel(false);
            InitializeCard();
        }

        public void InitializeCard()
        {
            for (int i = 0; i < friendSOs.Count; i++)
            {
                FriendCard fc = Instantiate(friendCardPrefab, contentParent);
                fc.InitializeCard(friendSOs[i]);
            }
        }

        public void ShowPanel(bool show)
        {
            friendPanel.SetActive(show);
        }
    }
}
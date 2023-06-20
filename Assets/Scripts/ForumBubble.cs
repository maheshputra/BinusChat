using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

namespace BinusChat
{
    public class ForumBubble : MonoBehaviour
    {
        [SerializeField] private ForumSO forumSO;
        [SerializeField] private TextMeshProUGUI textTitle;
        [SerializeField] private TextMeshProUGUI textDetail;
        private DateTime dateTime;

        [Header("Debug")]
        [SerializeField] private bool initializeOnStart;
        public void Start()
        {
            if (initializeOnStart) InitializeBubble(forumSO);
        }
        public void InitializeBubble(ForumSO forumSO)
        {
            this.forumSO = forumSO;
            textTitle.text = forumSO.forumTitle;

            dateTime = DateTime.ParseExact(forumSO.postDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            textDetail.text = forumSO.postDate + " - ";
            textDetail.text += forumSO.forumCourse;

            Debug.Log(dateTime); // Outputs: 12/20/2023 12:00:00 AM
        }

        public void ShowForum()
        {
            ForumScreen.instance.InitializeForumScreen(forumSO);
        }
    }
}
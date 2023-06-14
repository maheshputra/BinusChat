using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BinusChat
{
    public class ChatController : MonoBehaviour
    {
        public static ChatController instance;

        [Header("Settings")]
        [SerializeField] private Transform chatContent;

        [Header("UI")]
        [SerializeField] private ChatBubbleUser prefabChatBubbleUser;
        [SerializeField] private ChatBubbleFriend prefabChatBubbleFriend;
        [SerializeField] private TMP_InputField inputFieldChat;

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        public void PublishMessage(string text)
        {
            ChatBubbleUser cbu = Instantiate(prefabChatBubbleUser, chatContent);
            cbu.UpdateChat(text);
        }

        public void PublishBotMessage(string text)
        {
            ChatBubbleFriend cbf = Instantiate(prefabChatBubbleFriend, chatContent);
            cbf.UpdateChat(text);
        }
    }
}
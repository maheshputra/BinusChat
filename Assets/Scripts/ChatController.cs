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
        private RectTransform chatContentRect;

        [Header("UI")]
        [SerializeField] private Canvas chatCanvas;
        [SerializeField] private ChatBubbleUser prefabChatBubbleUser;
        [SerializeField] private ChatBubbleFriend prefabChatBubbleFriend;
        [SerializeField] private TMP_InputField inputFieldChat;

        [Header("Status")]
        [SerializeField] private List<GameObject> chatBubbles;

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        private void Start()
        {
            chatCanvas.gameObject.SetActive(true);
            chatContentRect = chatContent.GetComponent<RectTransform>();
            EnableCanvas(false);
        }

        public void EnableCanvas(bool enable)
        {
            chatCanvas.enabled = enable;
        }

        public void LoadChat(ConversationSO conversationSO)
        {
            foreach (var item in chatBubbles)
            {
                Destroy(item);
            }

            foreach (var item in conversationSO.chatDatas)
            {
                if (item.isUser)
                {
                    PublishMessage(item.message);
                }
                else
                {
                    PublishBotMessage(item.message);
                }
            }
        }

        public void PublishMessage(string text)
        {
            ChatBubbleUser cbu = Instantiate(prefabChatBubbleUser, chatContent);
            cbu.UpdateChat(text);
            chatBubbles.Add(cbu.gameObject);
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);
        }

        public void PublishBotMessage(string text)
        {
            ChatBubbleFriend cbf = Instantiate(prefabChatBubbleFriend, chatContent);
            cbf.UpdateChat(text);
            chatBubbles.Add(cbf.gameObject);
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);
        }
    }
}
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
        [SerializeField] private OpenAIController openAIController;
        [SerializeField] private Transform chatContent;
        private RectTransform chatContentRect;

        [Header("UI")]
        [SerializeField] private Canvas chatCanvas;
        [SerializeField] private ChatBubbleUser prefabChatBubbleUser;
        [SerializeField] private ChatBubbleFriend prefabChatBubbleFriend;
        [SerializeField] private TextMeshProUGUI textHeaderName;
        [SerializeField] private TextMeshProUGUI textHeaderStatus;
        [SerializeField] private Scrollbar scrollbar;

        [Header("Status")]
        [SerializeField] private List<GameObject> chatBubbles;
        [SerializeField] private ConversationSO currentConversation;
        [SerializeField] private FriendSO currentFriend;

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

        public void LoadChat(FriendSO friendSO)
        {
            currentFriend = friendSO;

            openAIController.StartConversation(currentFriend.friendBackground);
            textHeaderName.text = currentFriend.firstName + " " + currentFriend.lastName;
            textHeaderStatus.text = currentFriend.statusMessage;

            foreach (var item in chatBubbles)
            {
                Destroy(item);
            }

            foreach (var item in currentFriend.chatDatas)
            {
                if (item.isUser)
                {
                    PublishMessage(item.message, false);
                }
                else
                {
                    PublishBotMessage(item.message, false);
                }
            }
        }

        public void PublishMessage(string text, bool addData = true)
        {
            ChatBubbleUser cbu = Instantiate(prefabChatBubbleUser, chatContent);
            cbu.UpdateChat(text);
            chatBubbles.Add(cbu.gameObject);
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);

            if (addData)
            {
                ChatData data = new ChatData();
                data.message = text;
                data.isUser = true;
                currentFriend.chatDatas.Add(data);
                ChatList.instance.UpdateLastChat();
            }

            StartCoroutine(ScrollToBottomCoroutine());
        }

        public void PublishBotMessage(string text, bool addData = true)
        {
            ChatBubbleFriend cbf = Instantiate(prefabChatBubbleFriend, chatContent);
            cbf.UpdateChat(currentFriend, text);
            chatBubbles.Add(cbf.gameObject);
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);

            if (addData)
            {
                ChatData data = new ChatData();
                data.message = text;
                data.isUser = false;
                currentFriend.chatDatas.Add(data);
                ChatList.instance.UpdateLastChat();
            }

            StartCoroutine(ScrollToBottomCoroutine());
        }

        public void CloseConversation()
        {
            foreach (var item in chatBubbles)
            {
                Destroy(item.gameObject);
            }
            chatBubbles.Clear();
            EnableCanvas(false);
        }
        private IEnumerator ScrollToBottomCoroutine()
        {
            yield return null; // Wait for a frame to ensure the layout has updated
            Canvas.ForceUpdateCanvases();
            scrollbar.value = 0f;
            Canvas.ForceUpdateCanvases();
        }
    }
}
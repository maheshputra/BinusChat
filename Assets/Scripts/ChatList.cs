using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    public class ChatList : MonoBehaviour
    {
        public static ChatList instance;

        [Header("Conversation")]
        [SerializeField] private List<ConversationSO> conversationSOs;
        [SerializeField] private Dictionary<FriendSO, ConversationSO> conversations = new Dictionary<FriendSO, ConversationSO>();
        public Dictionary<FriendSO, ConversationSO> Conversations => conversations;

        [Header("Chat Shortcut")]
        [SerializeField] private List<ChatShortcutBubble> chatShortcutBubbles;

        [Header("Chat List")]
        [SerializeField] private ChatListBubble chatListBubblePrefab;
        [SerializeField] private Transform chatListSpawnParent;

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        private void Start()
        {
            LoadConversations();
            InitializeChatShortcut();
            InitializeChatList();
        }

        private void LoadConversations()
        {
            foreach (var item in conversationSOs)
            {
                conversations.Add(item.friendSO, item);
            }
        }

        private void InitializeChatShortcut()
        {
            foreach (var item in chatShortcutBubbles)
            {
                item.gameObject.SetActive(false);
            }

            for (int i = 0; i < chatShortcutBubbles.Count; i++)
            {
                if (conversationSOs.Count < i + 1) break;

                ChatShortcutBubble csb = chatShortcutBubbles[i];
                ConversationSO cso = conversationSOs[i];
                csb.gameObject.SetActive(true);
                csb.InitializeBubble(cso.friendSO);
            }
        }

        private void InitializeChatList()
        {
            foreach (var item in conversationSOs)
            {
                ChatListBubble clb = Instantiate(chatListBubblePrefab, chatListSpawnParent);
                clb.InitializeBubble(item.friendSO, item.chatDatas[0].message);
            }
        }
    }
}
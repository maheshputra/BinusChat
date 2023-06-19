using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    public class ChatList : MonoBehaviour
    {
        public static ChatList instance;
        [SerializeField] private List<FriendSO> activeFriends;
        [Header("Chat Shortcut")]
        [SerializeField] private List<ChatShortcutBubble> chatShortcutBubbles;
        [SerializeField] private List<ChatListBubble> chatListBubbles;

        [Header("Chat List")]
        [SerializeField] private ChatListBubble chatListBubblePrefab;
        [SerializeField] private Transform chatListSpawnParent;

        [Header("Status")]
        [SerializeField] private ChatListBubble currentChatListBubble;

        private Dictionary<ChatListBubble, FriendSO> chatBubbleFriends = new Dictionary<ChatListBubble, FriendSO>();
        private Dictionary<FriendSO, ChatListBubble> friendChatListBubbles = new Dictionary<FriendSO, ChatListBubble>();
        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        private void Start()
        {
            InitializeChatShortcut();
            InitializeChatList();
        }

        private void InitializeChatShortcut()
        {
            foreach (var item in chatShortcutBubbles)
            {
                item.gameObject.SetActive(false);
            }

            for (int i = 0; i < chatShortcutBubbles.Count; i++)
            {
                if (activeFriends.Count < i + 1) break;

                ChatShortcutBubble csb = chatShortcutBubbles[i];
                csb.gameObject.SetActive(true);
                csb.InitializeBubble(activeFriends[i]);
            }
        }

        private void InitializeChatList()
        {
            foreach (var item in activeFriends)
            {
                ChatListBubble clb = Instantiate(chatListBubblePrefab, chatListSpawnParent);
                clb.InitializeBubble(item);
                chatListBubbles.Add(clb);
                chatBubbleFriends.Add(clb, item);
                friendChatListBubbles.Add(item, clb);
            }
        }

        public void SetLastBubble(FriendSO friendSO)
        {
            currentChatListBubble = friendChatListBubbles[friendSO];
            currentChatListBubble.UpdateBubble();
        }

        public void UpdateLastChat()
        {
            currentChatListBubble.transform.SetSiblingIndex(0);
            activeFriends.Remove(chatBubbleFriends[currentChatListBubble]);
            activeFriends.Insert(0, chatBubbleFriends[currentChatListBubble]);
            currentChatListBubble.UpdateBubble();
            InitializeChatShortcut();
        }

        public bool AddNewChat(FriendSO friendSO)
        {
            if (activeFriends.Contains(friendSO)) return false;
            ChatListBubble clb = Instantiate(chatListBubblePrefab, chatListSpawnParent);
            clb.InitializeBubble(friendSO);
            chatListBubbles.Add(clb);
            chatBubbleFriends.Add(clb, friendSO);
            friendChatListBubbles.Add(friendSO, clb);
            activeFriends.Insert(0, friendSO);
            clb.OpenChat();
            return true;
        }
    }
}
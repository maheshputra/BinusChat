using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BinusChat
{
    public class ChatShortcutBubble : MonoBehaviour
    {
        [SerializeField] private FriendSO friendSO;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI textName;

        public void InitializeBubble(FriendSO friendSO)
        {
            this.friendSO = friendSO;
            image.sprite = friendSO.sprite;
            textName.text = friendSO.firstName;
        }

        public void OpenChat()
        {
            ChatController.instance.LoadChat(ChatList.instance.Conversations[friendSO]);
            ChatController.instance.EnableCanvas(true);
        }
    }
}
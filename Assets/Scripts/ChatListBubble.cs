using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BinusChat
{
    public class ChatListBubble : MonoBehaviour
    {
        [SerializeField] private FriendSO friendSO;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textLastMessage;

        public void InitializeBubble(FriendSO friendSO, string textLastMessage)
        {
            this.friendSO = friendSO;
            image.overrideSprite = friendSO.sprite;
            textName.text = friendSO.firstName + " " + friendSO.lastName;
            this.textLastMessage.text = textLastMessage;
        }

        public void OpenChat()
        {
            ChatController.instance.LoadChat(ChatList.instance.Conversations[friendSO]);
            ChatController.instance.EnableCanvas(true);
        }
    }
}
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

        public void InitializeBubble(FriendSO friendSO)
        {
            this.friendSO = friendSO;
            image.overrideSprite = friendSO.sprite;
            textName.text = friendSO.firstName + " " + friendSO.lastName;
            if (friendSO.chatDatas.Count > 0)
                this.textLastMessage.text = friendSO.chatDatas[friendSO.chatDatas.Count - 1].message;
            else
                this.textLastMessage.text = "";
        }

        public void UpdateBubble(){            
            if (friendSO.chatDatas.Count > 0)
                this.textLastMessage.text = friendSO.chatDatas[friendSO.chatDatas.Count - 1].message;
            else
                this.textLastMessage.text = "";
        }

        public void OpenChat()
        {
            ChatController.instance.LoadChat(friendSO);
            ChatController.instance.EnableCanvas(true);
            ChatList.instance.SetLastBubble(friendSO);
        }
    }
}
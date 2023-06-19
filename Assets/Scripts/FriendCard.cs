using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BinusChat
{
    public class FriendCard : MonoBehaviour
    {
        [SerializeField] private FriendSO friendSO;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI textName;

        public void InitializeCard(FriendSO friendSO)
        {
            this.friendSO = friendSO;
            image.overrideSprite = friendSO.sprite;
            textName.text = friendSO.firstName + " " + friendSO.lastName;
        }

        public void StartChat()
        {
            FriendList.instance.ShowPanel(false);
            ChatController.instance.LoadChat(friendSO);
            ChatController.instance.EnableCanvas(true);
            bool newChat = ChatList.instance.AddNewChat(friendSO);
            ChatList.instance.SetLastBubble(friendSO);
            ChatList.instance.UpdateLastChat();
        }
    }
}

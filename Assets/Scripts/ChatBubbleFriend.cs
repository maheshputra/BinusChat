using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BinusChat
{
    public class ChatBubbleFriend : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chatText;
        [SerializeField] private Image image;
        [SerializeField] private RectTransform chatContentRect;
        public void UpdateChat(FriendSO friend, string text)
        {
            image.overrideSprite = friend.sprite;
            chatText.text = text;
            LayoutRebuilder.MarkLayoutForRebuild(chatContentRect);
        }
    }
}
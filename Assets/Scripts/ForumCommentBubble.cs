using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BinusChat
{
    public class ForumCommentBubble : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textCommentatorName;
        [SerializeField] private TextMeshProUGUI textComment;

        public void InitializeCommentBubble(string commentator, string comment)
        {
            textCommentatorName.text = commentator;
            textComment.text = comment;
        }
    }
}
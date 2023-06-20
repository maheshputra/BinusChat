using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace BinusChat
{
    public class ForumScreen : MonoBehaviour
    {
        public static ForumScreen instance;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI textForumTitle;
        [SerializeField] private TextMeshProUGUI textForumCreator;
        [SerializeField] private TextMeshProUGUI textForumDescription;
        [SerializeField] private Transform commentParent;
        [SerializeField] private ForumCommentBubble commentBubblePrefab;

        [Header("Status")]
        [SerializeField] private List<GameObject> commentBubbles;
        [SerializeField] private ForumSO currentForum;

        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;
        }

        public void ShowForumScreen(ForumSO forumSO)
        {
            textForumTitle.text = forumSO.forumTitle;
            textForumCreator.text = forumSO.forumCreatorName;
            textForumDescription.text = forumSO.forumDescription;
            RefreshComment();
        }

        public void RefreshComment()
        {
            foreach (var item in commentBubbles)
            {
                Destroy(item);
            }

            commentBubbles.Clear();

            for (int i = 0; i < currentForum.forumDatas.Count; i++)
            {
                ForumData fd = currentForum.forumDatas[i];
                ForumCommentBubble fcb = Instantiate(commentBubblePrefab, commentParent);
                fcb.InitializeCommentBubble(fd.commentatorName, fd.comment);
            }
        }
    }
}
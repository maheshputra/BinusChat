using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BinusChat
{
    [CreateAssetMenu(fileName = "FriendSO", menuName = "ScriptableObjects/ForumSO")]
    public class ForumSO : ScriptableObject
    {
        public string forumCreatorName;
        public string forumTitle;
        public string forumDescription;
        public string forumCourse;
        public List<ForumData> forumDatas;

        [Header("dd/mm/yyyy format")]
        public string postDate;
    }
}
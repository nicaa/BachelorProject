using BLToolkit.Reflection;
using Garia.Core.DAO;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Handlers
{
    public class SocialHandler
    {
        public static List<Social> GetAllPost()
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetAllPost();
        }
        public static int DeletePostById(int SocialId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.DeletePostById(SocialId);
        }
        public static int CreatePost(string text, DateTime Date, string ImagePath, int EmployeeId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.CreatePost(text, Date, ImagePath, EmployeeId);
        }
        public static int CreateComment(string Comment, DateTime Date, string EmployeeName, int SocialId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.CreateComment(Comment, Date, EmployeeName, SocialId);
        }
        public static List<Comment> GetAllComments()
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetAllComments();
        }
        public static int CreateLike(int EmployeeId, int SocialId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.CreateLike(EmployeeId, SocialId);
        }
        public static List<Like> GetAllLikes()
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetAllLikes();
        }
        public static List<Comment> GetCommentById(int id)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetCommentById(id);
        }
        public static List<Like> GetLikesById(int id)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetLikesById(id);
        }
        public static int DeleteLikeById(int SocialId, int EmployeeId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.DeleteLikeById(SocialId, EmployeeId);
        }
        public static Like CheckLike(int EmployeeId, int SocialId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.CheckLike(EmployeeId, SocialId);
        }

        public static Social GetLatestPost() 
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetLatestPost();
        }

        public static Social GetPostById(int SocialId)
        {
            SocialDAO social = TypeAccessor<SocialDAO>.CreateInstance();
            return social.GetPostById(SocialId);
        }

    }
}

using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class SocialDAO : DataAccessor
    {
        [SprocName("tblSocial_GetAllPost")]
        public abstract List<Social> GetAllPost();

        [SprocName("tblSocial_DeletePostById")]
        public abstract int DeletePostById(int SocialId);

        [SprocName("tblSocial_CreatePost")]
        public abstract int CreatePost(string text, DateTime Date, string ImagePath, int EmployeeId);

        [SprocName("tblSocialComment_CreateComment")]
        public abstract int CreateComment(string Comment, DateTime Date, string EmployeeName, int SocialId);

        [SprocName("tblSocialComment_GetAllComments")]
        public abstract List<Comment> GetAllComments();

        [SprocName("tblSocialLike_CreateLike")]
        public abstract int CreateLike(int EmployeeId,int SocialId);

        [SprocName("tblSocialLike_GetAllLikes")]
        public abstract List<Like> GetAllLikes();

        [SprocName("tblSocialComment_GetCommentById")]
        public abstract List<Comment> GetCommentById(int id);

        [SprocName("tblSocialLike_GetLikeById")]
        public abstract List<Like> GetLikesById(int id);

        [SprocName("tblSocialLike_DeleteLikeById")]
        public abstract int DeleteLikeById(int SocialId, int EmployeeId);

        [SprocName("tblSocialLike_CheckLike")]
        public abstract Like CheckLike(int EmployeeId, int SocialId);

        [SprocName("tblSocial_GetLatestPost")]
        public abstract Social GetLatestPost();

        [SprocName("tblSocial_GetPostById")]
        public abstract Social GetPostById(int SocialId);

    }
}

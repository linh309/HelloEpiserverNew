using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;

namespace MyEpiserverSite.Models.Blocks
{
    [ContentType(DisplayName = "CommentUser", GUID = "0b50d755-9749-4260-994d-66f49cb9ef66", Description = "")]
    public class CommentUser : BlockData
    {
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
    }

    [ContentType]
    public class Comment : IContent
    {
        public virtual CommentUser User { get; set; }
        public virtual string Body { get; set; }

        private PropertyDataCollection _properties = new PropertyDataCollection();

        public Guid ContentGuid { get; set; }
        public ContentReference ContentLink { get; set; }
        public int ContentTypeID { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public ContentReference ParentLink { get; set; }
        public PropertyDataCollection Property { get { return _properties; } }

        public bool IsNull { get { return _properties.Count == 0; } }
    }

    public class CommentHandler
    {
        private IContentRepository _contentRepository;
        public CommentHandler(IContentRepository contentRepository)
        {
            this._contentRepository = contentRepository;
        }

        public Comment CreateAComment()
        {
            var comment = _contentRepository.GetDefault<Comment>(PageReference.RootPage, LanguageSelector.AutoDetect().Language);
            comment.Name = "acomment";
            comment.User.Email = "user@test.com";
            comment.Body = "This is a comment";

            var contentLink = _contentRepository.Save(comment, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            var loadedComment = _contentRepository.Get<Comment>(contentLink);

            System.Diagnostics.Debug.Assert(comment.User.Email == loadedComment.User.Email);
            System.Diagnostics.Debug.Assert(comment.Body == loadedComment.Body);

            return comment;
        }
    }
}
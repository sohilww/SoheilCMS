using System;
using System.Collections.Generic;
using Articles.DomainModel;

namespace Articles.Contracts
{
    public class PostCreateModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int VisitCount { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public string PostImage { get; set; }

        public string Slug { get; set; }

        public int AuthorId { get; set; }

        public int TagId { get; set; }

        public int CategoryId { get; set; }

        public AuthorRefrence Author { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<PostTag> PostTag { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public Post ToPost(Post current = null)
        {
            if (current == null)
            {
                current = new Post(title: Title, sendDate: SendDate, publishedDate: PublishedDate
                    , visitCount: VisitCount, content: Content, author: Author, authorId: AuthorId, category: Category,
                    categoryId: CategoryId, description: Description, postImage: PostImage, slug: Slug, tagId: TagId);

                current.Id = this.PostId;
            }
            else
            {
                current.Update(title: Title, sendDate: SendDate, publishedDate: PublishedDate
                    , visitCount: VisitCount, content: Content, author: Author, authorId: AuthorId, category: Category,
                    categoryId: CategoryId, description: Description, postImage: PostImage, slug: Slug, tagId: TagId);
            }
            return current;
        }
    }
}
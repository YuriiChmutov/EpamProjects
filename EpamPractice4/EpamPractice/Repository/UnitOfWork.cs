using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpamPractice.DAL;

namespace EpamPractice.Repository
{
    public class UnitOfWork: IDisposable
    {
        private BlogContext db = new BlogContext();
        private ArticleRepository articleRepository;
        private TagRepository tagRepository;

        public ArticleRepository Articles
        {
            get
            {
                if(articleRepository == null)
                {
                    articleRepository = new ArticleRepository();
                }
                return articleRepository;
            }
        }

        public TagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                {
                    tagRepository = new TagRepository();
                }
                return tagRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
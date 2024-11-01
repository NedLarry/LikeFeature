using likeFeature.Domain;
using likeFeature.Domain.request;
using Microsoft.EntityFrameworkCore;

namespace likeFeature.Services
{
    public class ArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<object> GetArticleLikeCount(int articleId)
        {
            try
            {

                var article = await _context.Articles.Where(a => a.Id.Equals(articleId)).FirstOrDefaultAsync();

                if (article is null)
                {
                    return new
                    {
                        sucess = false,
                        message = $"Article not found"

                    };
                }

                return new
                {
                    success = true,
                    ArticleLikeCount = article.LikeCount
                };

            }catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }

        public async Task<object> LikeArticle(LikeArticleRequest request)
        {
            try
            {

                var article = await _context.Articles.Where(a => a.Id.Equals(request.ArticleId)).FirstOrDefaultAsync();

                if (article is null)
                {
                    return new
                    {
                        sucess = false,
                        message = $"Article not found"

                    };
                }

                article.LikeCount++;

                _context.Articles.Update(article);

                await _context.SaveChangesAsync();


                return new
                {
                    success = true,
                    ArticleLikeCount = article.LikeCount
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }

        public async Task<object> GetAllArticles()
        {
            try
            {

                var article = await _context.Articles.ToListAsync();

                return new
                {
                    success = true,
                    data = article
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }
    }
}

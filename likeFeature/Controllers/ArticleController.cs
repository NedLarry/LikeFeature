using likeFeature.Domain.request;
using likeFeature.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace likeFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("getArticles")]
        public async Task<IActionResult> GetArticleLikeCount()
        {
            return Ok(await _articleService.GetAllArticles());
        }

        [HttpGet("GetLikeCount/{articleId}")]
        public async Task<IActionResult> GetArticleLikeCount(int articleId)
        {
            return Ok(await _articleService.GetArticleLikeCount(articleId));
        }

        [HttpPost("LikeArticle")]
        public async Task<IActionResult> LikeArticle(LikeArticleRequest request)
        {
            return Ok(await _articleService.LikeArticle(request));
        }
    }
}

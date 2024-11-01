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

        [HttpGet("LikeCount/{articleId}")]
        public async Task<IActionResult> GetArticleLikeCount(int articleId)
        {
            return Ok(await _articleService.GetArticleLikeCount(articleId));
        }

        [HttpGet("LikeArticle/{articleId}")]
        public async Task<IActionResult> LikeArticle(int articleId)
        {
            return Ok(await _articleService.LikeArticle(articleId));
        }
    }
}

using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models.WriteModels;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("campgrounds")]
    public class CampgroundController : ControllerBase
    {
        private readonly ICampgroundRepository _campgroundRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IImageRepository _imageRepository;

        public CampgroundController(ICampgroundRepository campgroundRepository, IUserRepository userRepository, ICommentRepository commentRepository, IImageRepository imageRepository)
        {
            _campgroundRepository = campgroundRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CampgroundsResponseModel>> GetCampgrounds()
        {
            var campgrounds = await _campgroundRepository.GetAllAsync();

            return campgrounds.Select(campground => new CampgroundsResponseModel
            {
                Id = campground.Id,
                Name = campground.Name,
                Price = campground.Price,
                Description = campground.Description,
                ImageUrl = campground.Url
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CampgroundResponseModel>> GetCampground(Guid id)
        {
            var campground = await _campgroundRepository.GetAsync(id);

            if (campground is null)
            {
                return NotFound($"Campground with id: {id} does not exist.");
            }

            var commentsToResponse = await _commentRepository.GetByCampgroundIdAsync(id);

            var comments = commentsToResponse.Select(comment => new CommentResponseModel
            {
                Id = comment.Id,
                Raiting = comment.Raiting,
                Text = comment.Text,
                UserId = comment.UserId,
                DateCreated = comment.DateCreated
            });

            var commentsList = comments.ToList();

            var imagesToResponse = await _imageRepository.GetByCampgroundIdAsync(id);

            var images = imagesToResponse.Select(image => new ImagesResponseModel
            {
                Id = image.Id,
                Url = image.Url
            });

            var imagesList = images.ToList();

            return new CampgroundResponseModel
            {
                Id = campground.Id,
                Name = campground.Name,
                Price = campground.Price,
                Description = campground.Description,
                Images = imagesList,
                Comments = commentsList
            };
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SaveCampgroundResponseModel>> CreateCampground([FromBody] SaveCampgroundRequestModel request)
        {
            var localId = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "user_id").Value;

            var user = await _userRepository.GetAsync(localId);

            var campground = new CampgroundWriteModel
            { 
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                DateCreated = DateTime.Now
            };

            await _campgroundRepository.SaveOrUpdateAsync(campground);

            return CreatedAtAction(nameof(GetCampground), new { id = campground.Id }, new SaveCampgroundResponseModel
            {
                Id = campground.Id,
                UserId = campground.UserId,
                Name = campground.Name,
                Price = campground.Price,
                Description = campground.Description,
                DateCreated = campground.DateCreated
            });
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<UpdateCampgroundResponseModel>> UpdateCampground(Guid id, [FromBody] UpdateCampgroundRequestModel request)
        {
            if (request is null)
            {
                return BadRequest();
            }

            var existCampground = await _campgroundRepository.GetAsync(id);

            if (existCampground is null)
            {
                return NotFound($"Campground with id: {id} does not exist");
            }

            var localId = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "user_id").Value;

            var user = await _userRepository.GetAsync(localId);

            var campgroundUpdate = await _campgroundRepository.GetAsync(id, user.Id);

            if (campgroundUpdate is null)
            {
                return BadRequest($"The user with e-mail: {user.Email} does not have permission to edit information of this campground.");
            }

            var campground = new CampgroundWriteModel
            {
                Id = id,
                UserId = campgroundUpdate.UserId,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                DateCreated = campgroundUpdate.DateCreated
            };

            await _campgroundRepository.SaveOrUpdateAsync(campground);

            return CreatedAtAction(nameof(GetCampground), new { id = campground.Id }, new UpdateCampgroundResponseModel
            {
                Name = campground.Name,
                Price = campground.Price,
                Description = campground.Description,
            });
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCampgroud(Guid id)
        {
            var existCampground = await _campgroundRepository.GetAsync(id);

            if (existCampground is null)
            {
                return NotFound($"Campground with id: {id} does not exist.");
            }

            var localId = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "user_id").Value;

            var user = await _userRepository.GetAsync(localId);

            var campgroundToDelete = await _campgroundRepository.GetAsync(id, user.Id);

            if (campgroundToDelete is null)
            {
                return BadRequest($"The user with e-mail: {user.Email} does not have permission to delete this campground.");
            }

            var taskToDeleteComments = _commentRepository.DeleteByCampgroundIdAsync(id);
            var taskToDeleteImages = _imageRepository.DeleteByCampgroundIdAsync(id);
            var taskToDeleteCampground = _campgroundRepository.DeleteAsync(id);

            await Task.WhenAll(taskToDeleteComments, taskToDeleteImages, taskToDeleteCampground);

            return NoContent();
        }
    }
}

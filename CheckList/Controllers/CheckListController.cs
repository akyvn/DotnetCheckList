using checkList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckList.Dtos;

namespace CheckList.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CheckListController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CheckListController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<GetCheckListItemDto> GetCheckListItem(int userId)
        {
            return _context.UserCheckListItems
            .Where(i => i.UserId == userId && i.IsSoftDeleted == false)
            .Select(uc => new GetCheckListItemDto
            {
                Id = uc.Id,
                Description = uc.Description,
                Title = uc.Title,
                IsResolved = uc.IsResolved,
                UserId = uc.UserId
            })
            .ToList();
        }

        [HttpPost]
        public string PostCheckListItem(CreateUserCheckListItemDto dto)
        {
            var userCheckListItem = new UserCheckListItem
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId
            };
            _context.UserCheckListItems.Add(userCheckListItem);
            _context.SaveChanges();
            return "ok";
        }
        [HttpPut]
        public string PutCheckListItem(UpdateUserCheckListItemDto dto)
        {

            var UserCheckListItem = _context.UserCheckListItems.FirstOrDefault(uc => uc.Id == dto.Id);
            if (UserCheckListItem is not null)
            {
                UserCheckListItem.Title = dto.Title;
                UserCheckListItem.Description = dto.Description;
                UserCheckListItem.IsResolved = dto.IsResolved;
            }
            _context.SaveChanges();
            return "ok";
        }
        [HttpDelete]
        public string DeleteCheckListItem(int Id)
        {
            var UserCheckListItem = _context.UserCheckListItems.FirstOrDefault(uc => uc.Id == Id);
            if (UserCheckListItem is not null)
            {
                UserCheckListItem.IsSoftDeleted = true;
            }
            _context.SaveChanges();
            return "ok";
        }
    }

}
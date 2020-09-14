using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private BookingDbContext dbContext;
        private UserManager<User> userManager;



        public FriendController(BookingDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [Route("AddFriend")]
        public async Task<ActionResult> AddFriend(string friendUsername)
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            if (username.Equals(friendUsername))
                return BadRequest();

            FriendRequest request = dbContext.FriendRequests.FirstOrDefault(fr => 
                fr.From == username && fr.To == friendUsername ||
                fr.From == friendUsername && fr.To == username);

            if (request == null)
            {
                request = new FriendRequest()
                {
                    From = username,
                    To = friendUsername,
                    Sent = DateTime.Now,
                    Status = FriendRequest.EStatus.Sent
                };

                dbContext.FriendRequests.Add(request);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteFriend")]
        public async Task<ActionResult> DeleteFriend(string friendUsername)
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            FriendRequest request = dbContext.FriendRequests.FirstOrDefault(fr => 
                fr.From == username && fr.To == friendUsername ||
                fr.From == friendUsername && fr.To == username);

            if (request != null)
            {
                dbContext.Entry(request).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("GetFriendRequests")]
        public async Task<IEnumerable<User>> GetFriendRequests()
        {
            string user = User.Claims.First(c => c.Type == "UserName").Value;

            IEnumerable<FriendRequest> friendRequests = dbContext.FriendRequests.Where(fr =>
                fr.To == user &&
                fr.Status == FriendRequest.EStatus.Sent);

            List<User> requests = new List<User>();

            foreach (FriendRequest fr in friendRequests)
            {
                User sender = await userManager.FindByNameAsync(fr.From);

                if (sender != null)
                    requests.Add(sender);
            }

            return requests;
        }

        [HttpGet]
        [Authorize]
        [Route("GetFriends")]
        public async Task<IEnumerable<User>> GetFriends()
        {
            string user = User.Claims.First(c => c.Type == "UserName").Value;

            IEnumerable<FriendRequest> requests = dbContext.FriendRequests.Where(fr =>
                (fr.From == user || fr.To == user) &&
                fr.Status == FriendRequest.EStatus.Accepted);

            List<User> friends = new List<User>();

            foreach (FriendRequest r in requests)
            {
                string friendUsername = r.From == user ? r.To : r.From;
                User friend = await userManager.FindByNameAsync(friendUsername);

                if (friend != null)
                    friends.Add(friend);
            }

            return friends;
        }

        [HttpPost]
        [Authorize]
        [Route("AcceptFriendRequest")]
        public async Task<ActionResult> AcceptFriendRequest(string friendUsername)
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            FriendRequest request = dbContext.FriendRequests.FirstOrDefault(fr => fr.From == friendUsername && fr.To == username);

            if (request != null)
            {
                request.Status = FriendRequest.EStatus.Accepted;

                dbContext.FriendRequests.Attach(request);
                dbContext.Entry(request).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("DeclineFriendRequest")]
        public async Task<ActionResult> DeclineFriendRequest(string friendUsername)
        {
            string username = User.Claims.First(c => c.Type == "UserName").Value;

            FriendRequest request = dbContext.FriendRequests.FirstOrDefault(fr => fr.From == friendUsername && fr.To == username);

            if (request != null)
            {
                dbContext.Entry(request).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

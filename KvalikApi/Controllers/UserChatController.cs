using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatController : ControllerBase
    {
        private readonly ContextDb _context;

        public UserChatController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/UserChat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserChat>>> GetUserChats()
        {
            return await _context.UserChat
                .Include(uc => uc.firstUser)
                .Include(uc => uc.secondUser)
                .ToListAsync();
        }

        // GET: api/UserChat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserChat>> GetUserChat(int id)
        {
            var userChat = await _context.UserChat
                .Include(uc => uc.firstUser)
                .Include(uc => uc.secondUser)
                .FirstOrDefaultAsync(uc => uc.id == id);

            if (userChat == null)
            {
                return NotFound();
            }

            return userChat;
        }

        // PUT: api/UserChat/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserChat(int id, UserChatRequest userChatRequest)
        {
            var userChat = await _context.UserChat.FindAsync(id);
            if (userChat == null)
            {
                return NotFound();
            }

            userChat.firstUserId = userChatRequest.firstUserId;
            userChat.secondUserId = userChatRequest.secondUserId;
            userChat.created_at = userChatRequest.created_at;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserChatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserChat
        [HttpPost]
        public async Task<ActionResult<UserChat>> PostUserChat(UserChatRequest userChatRequest)
        {
            var userChat = new UserChat
            {
                firstUserId = userChatRequest.firstUserId,
                secondUserId = userChatRequest.secondUserId,
                created_at = userChatRequest.created_at
            };

            _context.UserChat.Add(userChat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserChat", new { id = userChat.id }, userChat);
        }

        // DELETE: api/UserChat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserChat(int id)
        {
            var userChat = await _context.UserChat.FindAsync(id);
            if (userChat == null)
            {
                return NotFound();
            }

            _context.UserChat.Remove(userChat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserChatExists(int id)
        {
            return _context.UserChat.Any(e => e.id == id);
        }
    }
} 
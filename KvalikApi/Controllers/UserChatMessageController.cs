using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatMessageController : ControllerBase
    {
        private readonly ContextDb _context;

        public UserChatMessageController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/UserChatMessage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserChatMessage>>> GetUserChatMessages()
        {
            return await _context.UserChatMessage
                .Include(ucm => ucm.chat)
                .Include(ucm => ucm.user)
                .ToListAsync();
        }

        // GET: api/UserChatMessage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserChatMessage>> GetUserChatMessage(int id)
        {
            var userChatMessage = await _context.UserChatMessage
                .Include(ucm => ucm.chat)
                .Include(ucm => ucm.user)
                .FirstOrDefaultAsync(ucm => ucm.id == id);

            if (userChatMessage == null)
            {
                return NotFound();
            }

            return userChatMessage;
        }

        // PUT: api/UserChatMessage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserChatMessage(int id, UserChatMessageRequest userChatMessageRequest)
        {
            var userChatMessage = await _context.UserChatMessage.FindAsync(id);
            if (userChatMessage == null)
            {
                return NotFound();
            }

            userChatMessage.chatId = userChatMessageRequest.chatId;
            userChatMessage.userId = userChatMessageRequest.userId;
            userChatMessage.message = userChatMessageRequest.message;
            userChatMessage.sent_at = userChatMessageRequest.sent_at;
            userChatMessage.photoUrl = userChatMessageRequest.photoUrl;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserChatMessageExists(id))
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

        // POST: api/UserChatMessage
        [HttpPost]
        public async Task<ActionResult<UserChatMessage>> PostUserChatMessage(UserChatMessageRequest userChatMessageRequest)
        {
            var userChatMessage = new UserChatMessage
            {
                chatId = userChatMessageRequest.chatId,
                userId = userChatMessageRequest.userId,
                message = userChatMessageRequest.message,
                sent_at = userChatMessageRequest.sent_at,
                photoUrl = userChatMessageRequest.photoUrl
            };

            _context.UserChatMessage.Add(userChatMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserChatMessage", new { id = userChatMessage.id }, userChatMessage);
        }

        // DELETE: api/UserChatMessage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserChatMessage(int id)
        {
            var userChatMessage = await _context.UserChatMessage.FindAsync(id);
            if (userChatMessage == null)
            {
                return NotFound();
            }

            _context.UserChatMessage.Remove(userChatMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserChatMessageExists(int id)
        {
            return _context.UserChatMessage.Any(e => e.id == id);
        }
    }
} 
using Microsoft.EntityFrameworkCore;
using chatLab.Models;

namespace chatLab.Context
{
    public class ChatContext: DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
        public virtual DbSet<chatmessage> ChatMessages { get; set; }
    }
}

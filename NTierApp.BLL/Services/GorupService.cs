using Microsoft.EntityFrameworkCore;
using NTierApp.Core.Interfaces;
using NTierApp.Core.Models;
using NTierApp.DAL.Contexts;


namespace NTierApp.BLL.Services
{
    public class GroupService : IGroupInterface
    {
        public async Task<List<Group>> CreateGroupAsync(List<Group> groups)
        {
            AppDBContext dbContext = new AppDBContext();
            if (groups != null)
            {
                await dbContext.Groups.AddRangeAsync(groups);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Groups created successfully.");
                return groups;
            }else throw new ArgumentNullException(nameof(groups), "Groups cannot be null."); 
        }
        public async Task DeleteGroupAsync(Guid id)
        {
            AppDBContext ctx = new AppDBContext();
            var group = await ctx.Groups.FindAsync(id);
            if (group != null)
            {
                ctx.Groups.Remove(group);
                await ctx.SaveChangesAsync();
                Console.WriteLine("Group deleted successfully.");
            }
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            AppDBContext ctx = new AppDBContext();
            if (!await ctx.Groups.AnyAsync())
            {
                throw new InvalidOperationException("No groups found.");
            }
            return await ctx.Groups.AsNoTracking().ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(Guid id)
        {
            AppDBContext context = new AppDBContext();
            var group = await context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new InvalidOperationException("Group not found.");
            }
            return group;
        }

        public async Task<Group> GetGroupByNameAsync(string groupName)
        {
            AppDBContext context = new AppDBContext();
            var group = await context.Groups.FirstOrDefaultAsync(g => g.Name == groupName);
            if (group == null)
            {
                throw new InvalidOperationException("Group not found.");
            }
            return group;
        }

        public Task<Group> Isdeleted(Guid id)
        {
            AppDBContext context = new AppDBContext();
            var group = context.Groups.Find(id);
            if (group != null)
            {
                group.IsDeleted = true;
                group.DeletedAt = DateTime.Now;
                context.Groups.Update(group);
                context.SaveChanges();
                Console.WriteLine("Group marked as deleted.");
                return Task.FromResult(group);
            }
            else throw new InvalidOperationException("Group not found.");
        }

        

        public async Task<Group> UpdateGroupAsync(Guid id, Group group)
        {
            AppDBContext context = new AppDBContext();
            var existingGroup = await context.Groups.FindAsync(id);
            if (existingGroup == null)
                throw new InvalidOperationException("Group not found.");
            
            var sameNameGroup = await context.Groups.FirstOrDefaultAsync(g => g.Name == group.Name && g.Id != id);
            if (sameNameGroup != null)
                throw new InvalidOperationException("A group with the same name already exists.");

            existingGroup.Name = group.Name;
            existingGroup.Description = group.Description;

            context.Groups.Update(existingGroup);
            await context.SaveChangesAsync();

            return existingGroup;
        }
    }
}


using NTierApp.Core.Models;

namespace NTierApp.Core.Interfaces
{
    public interface IGroupInterface
    {
        public Task<List<Group>> CreateGroupAsync(List<Group> groups);
        public Task<Group> GetGroupByIdAsync(Guid id);
        public Task<Group> GetGroupByNameAsync(string groupName);
        public Task<List<Group>> GetAllGroupsAsync();
        public Task<Group> UpdateGroupAsync(Guid id, Group group);
        public Task<Group> Isdeleted(Guid id);
        public Task DeleteGroupAsync(Guid id);
        

    }
}

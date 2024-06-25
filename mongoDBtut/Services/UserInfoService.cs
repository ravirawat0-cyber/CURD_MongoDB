using MongoDB.Driver;
using mongoDBtut.Models;

namespace mongoDBtut.Services
{
    public class UserInfoService
    {
        private readonly IMongoCollection<UserInfo> _userInfoCollection;

        public UserInfoService(DbContext context)
        {
            _userInfoCollection = context.UserInfo;
        }

        public async Task<List<UserInfo>> GetAsync() =>
            await _userInfoCollection.Find(u => true).ToListAsync();

        public async Task<UserInfo> GetAsync(string id) =>
            await _userInfoCollection.Find<UserInfo>(u => u.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserInfo user) =>
            await _userInfoCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, UserInfo user) =>
            await _userInfoCollection.ReplaceOneAsync(u => u.Id == id, user);

        public async Task RemoveAsync(string id) =>
            await _userInfoCollection.DeleteOneAsync(u => u.Id == id);
    }
}

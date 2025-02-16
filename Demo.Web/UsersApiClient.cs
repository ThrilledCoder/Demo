using Demo.Core.Models;

namespace Demo.Web;

public class UsersApiClient(HttpClient httpClient)
{
    public async Task<IQueryable<User>?> GetUsersAsync(int maxItems = 100, CancellationToken cancellationToken = default)
    {
        List<User>? users = null;

        await foreach (var user in httpClient.GetFromJsonAsAsyncEnumerable<User>("/api/users", cancellationToken))
        {
            if (users?.Count >= maxItems)
            {
                break;
            }
            if (user is not null)
            {
                users ??= [];
                users.Add(user);
            }
        }

        return users?.AsQueryable();
    }
}

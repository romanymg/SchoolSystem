using Common.Models;
using System;

namespace Common.Helpers
{
    public interface ICurrentRequest
    {
        public string? BaseUrl { get; }
        public string? Host { get; }
        public string? UserIp { get; }
        public string? Origin { get; }
        public string Platform { get; }
        public bool IsArabic { get; }

        public long CurrentUserId { get; }
        public string CurrentUserName { get; }
    }
}

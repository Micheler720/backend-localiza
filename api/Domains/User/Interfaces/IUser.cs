using System;

namespace Domains.User
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using FrameWork.Domain.Model;

namespace Authors.DomainModel
{
    public class Author : EntityBase<int>
    {
        protected Author()
        {
            
        }
        public Author(string name, string lastName, string userName, string email, int roleId)
        {
            SetProperty(name, lastName, userName,email,roleId);
        }
        private void SetProperty(string name, string lastName, string userName, string email, int roleId)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
            Email = email;
            RoleId = roleId;
        }

        public void Update(string name, string lastName, string userName, string email, int roleId)
        {
            SetProperty(name, lastName, userName, email, roleId);
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }

        public string UserName { get; private set; }

        public string Email { get;private set; }

        public int RoleId { get;private set; }
        public ICollection<PostRefrence> Posts { get; private set; }
        public string Password  { get;private set; }
    }
}
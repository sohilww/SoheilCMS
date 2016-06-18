using System.Collections.Generic;
using FrameWork.Domain.Model;

namespace Articles.DomainModel
{
    public class AuthorRefrence:EntityBase<int>
    {
        protected AuthorRefrence()
        {
            
        }
        public AuthorRefrence(string name, string lastName, string userName)
        {
            SetProperty(name, lastName, userName);
        }

        private void SetProperty(string name, string lastName, string userName)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
        }
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public string UserName { get; private set; }

        public ICollection<Post> Posts{ get; private set; }

        public string GetNameAndLastName()
        {
            return this.Name + "  " + this.LastName;
        }
    }
}
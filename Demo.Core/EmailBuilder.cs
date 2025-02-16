using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core
{
    public class EmailBuilder
    {
        private string? _firstName;
        private string? _lastName;
        private string? _domain;

        public EmailBuilder() { }

        public EmailBuilder SetFirstname(string firstname)
        {
            _firstName = firstname.ToLower();
            return this;
        }
        public EmailBuilder SetLastname(string lastname)
        {
            _lastName = lastname.ToLower();
            return this;
        }
        public EmailBuilder SetDomain(string domain)
        {
            _domain = domain.ToLower();
            return this;
        }

        public string Build()
        {
            return $"{_firstName}.{_lastName}@{_domain}";
        }
    }
}

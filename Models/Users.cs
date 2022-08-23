using System;
using System.Collections.Generic;

namespace EFCoreMVCMacoratti.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return this.Id + ": "
                + this.Nome
                + ": "
                + this.Email;
        }
    }
}

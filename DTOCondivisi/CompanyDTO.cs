using System;
using System.Collections.Generic;
using System.Text;

namespace it.Mifram.Dieci3k.DTO.Support
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppConfigConnection { get; set; }

        public CompanyDTO()
        {

        }
        public CompanyDTO(int id, string name, string appConfigConnection) : this()
        {
            this.Id = id;
            this.Name = name;
            this.AppConfigConnection = appConfigConnection;
        }

    }
}

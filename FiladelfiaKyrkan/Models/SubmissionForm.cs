using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiladelfiaKyrkan.Models;
namespace FiladelfiaKyrkan.Models
{
    public class SubmissionForm
    {
        public int Id { get; set; }
        public virtual ApplicationUser User  { get; set; }
        public string Message { get; set; }
        public string MinistryName { get; set; }
    }
}
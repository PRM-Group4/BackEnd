using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Response
{
	public class UserResponse
	{
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public int? RoleId { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Status { get; set; }

        public string? Position { get; set; }

        public string? ContactInfo { get; set; }

    }
}

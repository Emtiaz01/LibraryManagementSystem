﻿namespace LibraryManagementSystem.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

    }
}

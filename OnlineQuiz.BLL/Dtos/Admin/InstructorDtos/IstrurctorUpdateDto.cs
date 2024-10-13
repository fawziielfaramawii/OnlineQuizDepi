﻿using OnlineQuiz.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Dtos.Admin.InstructorDtos
{
    public class IstrurctorUpdateDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public GenderType Gender { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Adress { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
    }
}
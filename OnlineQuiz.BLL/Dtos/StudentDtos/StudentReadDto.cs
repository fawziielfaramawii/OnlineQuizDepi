﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Dtos.StudentDtos
{
    public class StudentReadDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Grade { get; set; }  
        public string ImgUrl { get; set; }


    }
}
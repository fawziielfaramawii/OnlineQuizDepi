﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.BLL.Dtos.Accounts.VM
{
    public class VerifyEmailVM
    {
        public string UserId { get; set; } 
        public string Message { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace journalProject.DB
{
    public class Connect
    {
        public static journalDBEntities connection = new journalDBEntities();
    }
}

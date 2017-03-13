﻿using AcademicsLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicsLibrary.Managers
{
    public class DataManager
    {

        public static User user { get; private set; }
        public static Response response { get; private set; }
        public static bool IsReady { get; private set; }

        public static async Task<bool> LoginAsync(string campus ,string reg , string pass)
        {
             user = await NetworkService.NetworkService.Login(campus ,reg,pass);
            if (user.status.code==0)
            {          
              
                IsReady = true;
                return true;
                //  await TrySaveDataAsync(response.Content);
            }
            else
            {
                return false;
            }   
        }


    }
}
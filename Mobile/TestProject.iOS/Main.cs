﻿using UIKit;

namespace TestProject.iOS
{
    public class Application
    {
        static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, nameof(AppDelegate));
            }
            catch (System.Exception ex)
            {

                throw;
            }

            
        }
    }
}